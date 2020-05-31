import React, { Component } from "react";
import { Card, Image, Row, Form, FormControl, Button } from "react-bootstrap";
import samLogo from "../User/lg1.jpeg";
import { BooksCards } from "./BookCards";
import { Modal, ModalHeader, ModalBody } from "reactstrap";
// import ReactPaginate from 'react-paginate';
import { Dropdown } from "semantic-ui-react";
import Emitter from "../../event-emitter";

const BOOKS_UPDATED = "BOOKS_UPDATED";
const tagOptions = [
  { key: "Empty", value: "Empty", text: "Все" },
  { key: "Менеджмент", value: "Менеджмент", text: "#Менеджмент" },
  { key: "Мотивация", value: "Мотивация", text: "#Мотивация" },
  { key: "Паттерны", value: "Паттерны", text: "#Паттерны" },
  { key: "Разработка", value: "Разработка", text: "#Разработка" },
  { key: "Тестирование", value: "Тестирование", text: "#Тестирование" },
];

const styleLink = document.createElement("link");
styleLink.rel = "stylesheet";
styleLink.href =
  "https://cdn.jsdelivr.net/npm/semantic-ui/dist/semantic.min.css";
document.head.appendChild(styleLink);

export class UserPage extends Component {
  static displayName = UserPage.name;

  constructor(props) {
    super(props);

    this.state = {
      books: [],
      userBooks: [],
      booksPerPage: [],
      total: 0,
      searchTerm: "",
      statuses: [],
      isUserBooks: false,
    };

    this.handleSubmitSearch = this.handleSubmitSearch.bind(this);
    this.onChangeSearch = this.onChangeSearch.bind(this);
    this.GetUserBooks = this.GetUserBooks.bind(this);
    this.tags = React.createRef();
  }

  async loadData() {
    let url = "api/book/getAllBooks";

    let response = await fetch(url);

    if (response.ok) {
      let responseJson = response.json();
      responseJson.then((results) => {
        this.setState({
          books: results,
          total: results.length,
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
    Emitter.on(BOOKS_UPDATED, async () => await this.loadData());
  }

  componentWillUnmount() {
    Emitter.off(BOOKS_UPDATED);
  }

  // handlePageClick = data => {
  //     // let selected = data.selected;
  //     // let offset = Math.ceil(selected * 6);

  //     // this.setState({ offset: offset }, () => {
  //     //   this.loadCommentsFromServer();
  //     // });
  //   };

  onChangeSearch(e) {
    e.persist();
    let val = e.target.value;
    this.setState({ searchTerm: val });
  }

  async GetUserBooks() {
    let bookIds = [];
    let statuses = {};
    let bookedStatusId = this.state.statuses.find(
      (status) => status.name === "Booked"
    );
    let givenToUserId = this.state.statuses.find(
      (status) => status.name === "GivenToUser"
    );

    this.state.books.forEach((book) => {
      const books = book.bookEntityViewModels;

      books.forEach((el) => {
        if (
          el.appUserId === this.props.userid &&
          (el.statusId === bookedStatusId.id ||
            el.statusId === givenToUserId.id)
        ) {
          bookIds.push(el.bookId);
          statuses[el.bookId] = el.statusId;
        }
      });
    });

    let userBooks = this.state.books
      .filter((i) => bookIds.includes(i.id))
      .map((i) => {
        return { ...i, statusId: statuses[i.id] };
      });
    this.setState({
      userBooks: userBooks,
      isUserBooks: true,
    });
  }

  async handleSubmitSearch(e) {
    e.preventDefault();
    let form = new FormData();
    form.append("termSearch", this.state.searchTerm);
    form.append("tagSearch", this.tags.current.state.value);

    debugger;

    let url = "api/boook/search";
    let method = "POST";

    let response = await fetch(url, {
      method: method,
      mode: "cors",
      body: form,
    });

    if (response.ok) {
      if (response.ok) {
        let responseJson = response.json();
        responseJson.then((results) => {
          this.setState({
            books: results,
            total: results.length,
            isUserBooks: false,
          });
        });
      }
      //window.location.replace("/Home");
    }
  }

  render() {
    return (
      <div>
        <Card
          className="text-left border p-5 col-md-12 rounded flex-row flex-wrap"
          style={{
            backgroundColor: "#EDE7F6",
            boxShadow: "5px 5px 10px #cccccc",
            margin: "0 auto",
            width: "100%",
          }}
        >
          <Image
            className="border"
            style={{
              width: "180px",
              height: "180px",
              boxShadow: "7px 7px 12px #cccccc",
            }}
            src={samLogo}
            alt="Logo"
            roundedCircle
          />
          <Card.Body>
            <Card.Text>
              <b>Email:</b> {this.props.useremail}
              <br />
              <b>Employee:</b> {this.props.username} {this.props.usersurname}
              <br />
              <b>Phone:</b> +{this.props.userphone}
              <br />
              <b>Floor:</b> {this.props.userfloor}
              <br />
              <b>Room:</b> {this.props.userroom}
            </Card.Text>
            <Button variant="outline-success" onClick={this.GetUserBooks}>
            My Books
          </Button>
          </Card.Body>
        </Card>
        <hr />
        <Card
          className="text-left border p-5 col-md-12 rounded flex-row flex-wrap"
          style={{
            backgroundColor: "#EDE7F6",
            boxShadow: "5px 5px 10px #cccccc",
            margin: "0 auto",
            width: "100%",
          }}
        >
          <Row>
            <Form inline onSubmit={this.handleSubmitSearch}>
              <Dropdown
                className="mr-4"
                placeholder="Select Tag"
                search
                selection
                defaultValue={"Empty"}
                options={tagOptions}
                ref={this.tags}
              />
              <FormControl
                type="text"
                placeholder="Search"
                className="mr-md-4"
                onChange={this.onChangeSearch}
              />
              <Button variant="outline-success" type="submit">
                Search
              </Button>
            </Form>
          </Row>
        </Card>
        <hr />
        {
          <BooksCards
            data={
              this.state.isUserBooks ? this.state.userBooks : this.state.books
            }
            statuses={this.state.statuses}
            userId={this.props.userid}
            isUserBooks={this.state.isUserBooks}
          />
        }
        {/* <ReactPaginate
                previousLabel={'previous'}
                nextLabel={'next'}
                breakLabel={'...'}
                breakClassName={'break-me'}
                pageCount={this.state.total}
                marginPagesDisplayed={2}
                pageRangeDisplayed={6}
                onPageChange={this.handlePageClick}
                containerClassName={'pagination'}
                subContainerClassName={'pages pagination'}
                activeClassName={'active'}
            /> */}
      </div>
    );
  }
}
