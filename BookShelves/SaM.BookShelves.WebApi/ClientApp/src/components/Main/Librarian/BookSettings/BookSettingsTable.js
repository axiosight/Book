import React, { Component } from "react";
import { Table, Button } from "react-bootstrap";

class Item extends Component {
  constructor(props) {
    super(props);

    this.handleDeleteBook = this.handleDeleteBook.bind(this);
  }

  handleDeleteBook() {
    let url = `api/book/deleteBook/${this.props.item.id}`;
    let method = "DELETE";

    let response = fetch(url, {
      method: method,
      mode: "cors",
    });
    if (response.ok) {
      alert("Delete!");
      window.location.replace("/Home");
    } else {
      alert("Delete!");
      window.location.replace("/Home");
    }
  }

  render() {
    return (
      <tr>
        <td className="text-center">
          <img
            height="120px"
            alt=""
            src={
              this.props.item.previewViewModelMain
                ? this.props.item.previewViewModelMain.imgUrl
                : ""
            }
          />
        </td>
        <td className="text-center">{this.props.item.name}</td>
        <td className="text-center">{this.props.item.year}</td>
        <td className="text-center">
          <Button
            onClick={this.handleDeleteBook}
            className="m-2"
            style={{ boxShadow: "5px 5px 10px #cccccc" }}
            variant="outline-danger"
            size="sm"
          >
            Delete
          </Button>
        </td>
      </tr>
    );
  }
}

export class BookSettingsTable extends Component {
  static displayName = BookSettingsTable.name;
  render() {
    return (
      <Table striped bordered hover responsive className="mt-2">
        <thead>
          <tr
            className="text-center"
            style={{ boxShadow: "5px 5px 10px #cccccc" }}
          >
            <th className="text-center">Image</th>
            <th className="text-center">Name</th>
            <th className="text-center">Year</th>
            <th className="text-center"></th>
          </tr>
        </thead>
        <tbody>
          {this.props.data.map(function (item) {
            return <Item key={item.id} item={item} />;
          })}
        </tbody>
      </Table>
    );
  }
}
