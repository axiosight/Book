import React, { Component } from "react";
import { Table, Button } from "react-bootstrap";
import Emitter from "../../event-emitter";

const ENTITIES_UPDATED = "ENTITIES_UPDATED";

var bookStatuses = {
  InLib: "InLib",
  Booked: "Booked",
  GivenToUser: "GivenToUser",
  Ready: "Ready",
  Transferred: "Transferred",
  Denied: "Denied",
};

var actions = {
  giveToUser: "GiveToUser",
  backToLib: "BackToLib",
};

export class Order extends Component {
  constructor(props) {
    super(props);

    this.changeStatus = this.changeStatus.bind(this);
  }
  static displayName = Order.name;

  async changeStatus(action, bookId) {
    const bookStatus =
      action === actions.giveToUser
        ? this.props.statuses.find(
            (status) => status.name === bookStatuses.GivenToUser
          )
        : this.props.statuses.find(
            (status) => status.name === bookStatuses.InLib
          );
    const url = `api/book/${bookId}/status/${bookStatus.id}`;
    const method = "POST";

    let response = await fetch(url, {
      method: method,
      mode: "cors",
    });

    if (response.ok) {
      Emitter.emit(ENTITIES_UPDATED, {});
    }
  }

  renderGiveToUserButton(statusName, bookId) {
    if (statusName === "GivenToUser") {
      return null;
    }
    return (
      <Button
        className="m-2"
        style={{ boxShadow: "5px 5px 10px #cccccc" }}
        variant="outline-danger"
        size="sm"
        onClick={() => this.changeStatus(actions.giveToUser, bookId)}
      >
        Give To User
      </Button>
    );
  }

  render() {
    return (
      <div>
        <Table striped bordered hover responsive className="mt-2">
          <thead>
            <tr
              className="text-center"
              style={{ boxShadow: "5px 5px 10px #cccccc" }}
            >
              <th className="text-center">User</th>
              <th className="text-center">Book</th>
              <th className="text-center">Status</th>
              <th className="text-center"></th>
            </tr>
          </thead>
          <tbody>
            {this.props.data.map((e) => {
              return (
                <tr>
                  <td className="text-center">
                    {e.userName} email: {e.email} floor: {e.floor} room:{" "}
                    {e.room}
                  </td>
                  <td className="text-center">{e.bookName}</td>
                  <td className="text-center">{e.statusName}</td>
                  <td className="text-center">
                    {this.renderGiveToUserButton(e.statusName, e.id)}
                    <Button
                      className="m-2"
                      style={{ boxShadow: "5px 5px 10px #cccccc" }}
                      variant="outline-danger"
                      size="sm"
                      onClick={() => this.changeStatus(actions.backToLib, e.id)}
                    >
                      Back to library
                    </Button>
                  </td>
                </tr>
              );
            })}
          </tbody>
        </Table>
      </div>
    );
  }
}
