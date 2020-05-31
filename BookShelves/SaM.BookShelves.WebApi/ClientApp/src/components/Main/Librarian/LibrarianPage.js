import React, { Component } from "react";
import { Tabs, Tab, Button } from "react-bootstrap";
import { Order } from "./Order";
import Emitter from "../../event-emitter";

const ENTITIES_UPDATED = "ENTITIES_UPDATED";

export class LibrarianPage extends Component {
  static displayName = LibrarianPage.name;

  constructor(props) {
    super(props);

    this.state = {
      orders: [],
      statuses: []
    };
  }

  async loadData() {
    let url = "api/book/booked";

    let response = await fetch(url);
    if (response.ok) {
      let responseJson = response.json();

      responseJson.then((results) => {
        this.setState({
          orders: results,
        });
      });
    }
  }

  async loadBookStatuses() {
    const url = "api/book/statuses";

    let response = await fetch(url);

    if (response.ok) {
      let responseJson = response.json();
      responseJson.then((results) => {
        this.setState({
          statuses: results,
        });
      });
    }
  }

  async componentDidMount() {
    await this.loadData();
    await this.loadBookStatuses();
    Emitter.on(ENTITIES_UPDATED, async () => await this.loadData());
  }

  componentWillUnmount() {
    Emitter.off(ENTITIES_UPDATED);
  }

  render() {
      console.log(this.state.orders)
    return (
      <Tabs defaultActiveKey="BooksSettings" id="uncontrolled-tab-example">
        <Tab eventKey="BooksSettings" title="BooksSettings">
          BooksSettings
        </Tab>
        <Tab eventKey="Orders" title="Orders">
          <Order data={this.state.orders} statuses={this.state.statuses} />
        </Tab>
      </Tabs>
    );
  }
}
