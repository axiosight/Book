import React, { Component } from "react";
import { Container } from "react-bootstrap";
import { NavMenu } from "../NavMenu";
import { AdminPage } from "./Admin/AdminPage";
import { UserPage } from "./User/UserPage";
import { LibrarianPage } from "./Librarian/LibrarianPage";

export class Home extends Component {
  static displayName = Home.name;

  constructor(props) {
    super(props);

    this.state = {
      userId: "",
      email: "",
      name: "",
      surname: "",
      mobile: "",
      floor: "",
      room: "",
      roles: [],
    };
  }

  async loadData() {
    let url = "api/account/getAccount";

    let response = await fetch(url);

    if (response.ok) {
      let responseJson = response.json();
      responseJson.then((results) => {
        this.setState({
          roles: results.roles,
          userId: results.userId,
          email: results.email,
          name: results.name,
          surname: results.surname,
          mobile: results.mobile,
          floor: results.floor,
          room: results.room,
        });
      });
    }
  }

  async componentDidMount() {
    await this.loadData();
  }

  renderPage() {
    let isUser = this.state.roles.indexOf("user");
    let isAdmin = this.state.roles.indexOf("admin");
    let isSitter = this.state.roles.indexOf("librarian");

    if (isAdmin !== -1) {
      return <AdminPage />;
    } else if (isUser !== -1) {
      return (
        <UserPage
          userid={this.state.userId}
          useremail={this.state.email}
          username={this.state.name}
          usersurname={this.state.surname}
          userphone={this.state.mobile}
          userfloor={this.state.floor}
          userroom={this.state.room}
        />
      );
    } else if (isSitter !== -1) {
      return <LibrarianPage />;
    } else {
      return <div>You need to sign in to use our app :) </div>;
    }
  }

  render() {
    return (
      <div>
        <NavMenu />
        <Container>{this.renderPage()}</Container>
      </div>
    );
  }
}
