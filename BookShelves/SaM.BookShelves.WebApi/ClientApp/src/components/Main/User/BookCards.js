import React, { Component } from "react";
import { Row, Card, Image, Button, Form } from "react-bootstrap";
import logo from "./bk1.png";
import { Modal, ModalHeader, ModalBody } from "reactstrap";
import Emitter from "../../event-emitter";

const BOOKS_UPDATED = "BOOKS_UPDATED";
var bgColors = {
  Default: "#faf8f7",
  Blue: "#00B1E1",
  Cyan: "#37BC9B",
  Green: "#8CC152",
  Red: "#E9573F",
  Yellow: "#F6BB42",
};

var bookStatuses = {
  InLib: "InLib",
  Booked: "Booked",
  GivenToUser: "GivenToUser",
  Ready: "Ready",
  Transferred: "Transferred",
  Denied: "Denied",
};

class Entity extends Component {
  constructor(props) {
    super(props);

    this.handleSubmit = this.handleSubmit.bind(this);
  }

  async rentBook() {
    const url = `api/book/${this.props.eid}/user/${this.props.userId}`;
    const method = "POST";

    await fetch(url, {
      method: method,
      mode: "cors",
    });
  }

  async handleSubmit(e) {
    e.preventDefault();

    const bookedStatus = this.props.statuses.find(
      (status) => status.name === bookStatuses.Booked
    );

    const url = `api/book/${this.props.eid}/status/${bookedStatus.id}`;
    const method = "POST";

    let response = await fetch(url, {
      method: method,
      mode: "cors",
    });

    if (response.ok) {
      await this.rentBook();
      Emitter.emit(BOOKS_UPDATED, {});
    }
  }

  render() {
    const statusName = this.props.statuses.find(
      (status) => status.id === this.props.estatus
    ).name;

    return (
      <div>
        <hr />
        <Form onSubmit={this.handleSubmit}>
          <p>Name: {this.props.bookName}</p>
          <p>Original name: {this.props.originalName}</p>
          <p style={{ textDecorationColor: "green" }}>Status: {statusName}</p>
          {statusName === bookStatuses.InLib ? (
            <Button
              type="submit"
              className="m-2"
              style={{ boxShadow: "5px 5px 10px #cccccc" }}
              variant="outline-primary"
              size="sm"
            >
              Rent
            </Button>
          ) : null}
        </Form>
        <hr />
      </div>
    );
  }
}

class BookItem extends Component {
  constructor(props) {
    super(props);

    this.state = {
      modalRent: false,
    };

    this.modalRentEntity = this.modalRentEntity.bind(this);
  }

  modalRentEntity() {
    this.setState({
      modalRent: !this.state.modalRent,
    });
  }

  render() {
    const statuses = this.props.statuses;
    const bookName = this.props.bookname;
    const userId = this.props.userId;
    const originalName = this.props.bookoriginalname;
    return (
      <Card
        className="m-2 mb-2"
        style={{
          width: "26rem",
          backgroundColor: bgColors.Default,
          boxShadow: "7px 7px 12px #cccccc",
        }}
      >
        <Card.Title>
          <center>
            <Image
              style={{
                height: "350px",
                boxShadow: "5px 5px 10px #cccccc",
              }}
              src={this.props.imageurl}
              alt="Logo"
            />
          </center>

          {/* {
                    this.props.bookimg.map(function(t){
                        return <div>{t.img}</div>
                    })
                } */}
        </Card.Title>
        <Card.Body>
          <Card.Text>
            <b>Name:</b> {bookName}
            <br />
            <b>ISBN:</b> {this.props.bookisbn}
            <br />
            <b>Year:</b> {this.props.bookyear}
            <br />
            <hr />
            {this.props.bookauthors.map(function (author) {
              return <div>{author.name}</div>;
            })}
            <hr />
            {this.props.bookpublishers.map(function (publisher) {
              return (
                <div>
                  <em>{publisher.name}</em>
                </div>
              );
            })}
            <hr />
            {this.props.booktags.map(function (tag) {
              return <div>#{tag.name}</div>;
            })}
            <br />
          </Card.Text>
        </Card.Body>
        <Card.Footer>
          {this.props.isUserBooks ? (
            <div>
              Status:{" "}
              {
                statuses.find((status) => this.props.bookStatusId === status.id)
                  .name
              }
            </div>
          ) : (
            <Button
              onClick={this.modalRentEntity}
              className="mb-2 col-md-4"
              style={{ boxShadow: "5px 5px 10px #cccccc" }}
              variant="primary"
            >
              Rent
            </Button>
          )}
        </Card.Footer>
        <div>
          <Modal isOpen={this.state.modalRent}>
            <ModalHeader toggle={this.modalRentEntity}>Rent Book</ModalHeader>
            <ModalBody>
              {this.props.bookentities.map(function (ent) {
                return (
                  <Entity
                    eid={ent.id}
                    ebook={ent.bookId}
                    bookName={bookName}
                    userId={userId}
                    originalName={originalName}
                    estatus={ent.statusId}
                    statuses={statuses}
                  />
                );
              })}
            </ModalBody>
          </Modal>
        </div>
      </Card>
    );
  }
}

export class BooksCards extends Component {
  static displayName = BooksCards.name;

  render() {
    const statuses = this.props.statuses;
    const userId = this.props.userId;
    const isUserBooks = this.props.isUserBooks;
    return (
      <Row>
        {this.props.data.map(function (item) {
          return (
            <BookItem
              key={item.id}
              isUserBooks={isUserBooks}
              bookStatusId={item.statusId}
              imageurl={item.previewViewModelMain.imgUrl}
              userId={userId}
              bookid={item.id}
              bookisbn={item.isbn}
              bookname={item.name}
              bookoriginalname={item.originalName}
              bookdescription={item.description}
              bookyear={item.year}
              booktags={item.tagViewModels}
              bookauthors={item.authorViewModels}
              bookpublishers={item.publisherViewModels}
              bookimg={item.previewViewModelMain}
              bookentities={item.bookEntityViewModels}
              statuses={statuses}
            />
          );
        })}
      </Row>
    );
  }
}
