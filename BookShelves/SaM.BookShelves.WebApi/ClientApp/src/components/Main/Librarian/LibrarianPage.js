import React, { Component } from "react";
import {
  Tabs,
  Tab,
  Button,
  Form,
  FormControl,
  Card,
  Row,
} from "react-bootstrap";
import { Order } from "./Order";
import Emitter from "../../event-emitter";
import { BookSettingsTable } from "./BookSettings/BookSettingsTable";
import { Modal, ModalHeader, ModalBody } from "reactstrap";

const ENTITIES_UPDATED = "ENTITIES_UPDATED";

export class LibrarianPage extends Component {
  static displayName = LibrarianPage.name;

  constructor(props) {
    super(props);

    this.state = {
      orders: [],
      statuses: [],
      allBooks: [],
      searchTerm: "",
      modalAddBook: false,

      name: "",
      nameIsValid: false,
      originalName: "",
      originalNameIsValid: false,
      isbn: "",
      isbnIsValid: false,
      year: "",
      yearIsValid: false,
      description: "",
      descriptionIsValid: false,
      authors: "",
      authorsIsValid: false,
      publishers: "",
      publishersIsValid: false,
      image: "",
      imageIsValid: false,
    };

    this.handleSubmitSearch = this.handleSubmitSearch.bind(this);
    this.onChangeSearch = this.onChangeSearch.bind(this);
    this.modalAddBook = this.modalAddBook.bind(this);
    this.handleAddBookSubmit = this.handleAddBookSubmit.bind(this);

    this.onChangeName = this.onChangeName.bind(this);
    this.onChangeOriginalName = this.onChangeOriginalName.bind(this);
    this.onChangeISBN = this.onChangeISBN.bind(this);
    this.onChangeYear = this.onChangeYear.bind(this);
    this.onChangeDescription = this.onChangeDescription.bind(this);
    this.onChangeAuthors = this.onChangeAuthors.bind(this);
    this.onChangePublishers = this.onChangePublishers.bind(this);
    this.onChangeImage = this.onChangeImage.bind(this);
  }

  modalAddBook() {
    this.setState({
      modalAddBook: !this.state.modalAddBook,
    });
  }

  onChangeSearch(e) {
    e.persist();
    let val = e.target.value;
    this.setState({ searchTerm: val });
  }

  async handleSubmitSearch(e) {
    e.preventDefault();
    let form = new FormData();
    form.append("termSearch", this.state.searchTerm);

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
            allBooks: results,
          });
        });
      }
    }
  }

  async loadAllBooks() {
    let url = "api/book/getAllBooks";

    let response = await fetch(url);
    if (response.ok) {
      let responseJson = response.json();

      responseJson.then((results) => {
        this.setState({
          allBooks: results,
        });
      });
    }
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
    await this.loadAllBooks();
    Emitter.on(ENTITIES_UPDATED, async () => await this.loadData());
  }

  componentWillUnmount() {
    Emitter.off(ENTITIES_UPDATED);
  }

  onChangeName(e) {
    e.persist();
    let val = e.target.value;
    let valid = this.validateName(val);
    this.setState({ name: val, nameIsValid: valid });
  }

  validateName(n) {
    return n.length > 2;
  }

  onChangeOriginalName(e) {
    e.persist();
    let val = e.target.value;
    let valid = this.validateOriginalName(val);
    this.setState({ originalName: val, originalNameIsValid: valid });
  }

  validateOriginalName(n) {
    return n.length > 2;
  }

  onChangeISBN(e) {
    e.persist();
    let val = e.target.value;
    let valid = this.validateISBN(val);
    this.setState({ isbn: val, isbnIsValid: valid });
  }

  validateISBN(n) {
    return n.length === 13;
  }

  onChangeYear(e) {
    e.persist();
    let val = e.target.value;
    let valid = this.validateYear(val);
    this.setState({ year: val, yearIsValid: valid });
  }

  validateYear(n) {
    let year = Number.parseInt(n);
    return year >= 1900 && year <= 2020;
  }

  onChangeDescription(e) {
    e.persist();
    let val = e.target.value;
    let valid = this.validateDescription(val);
    this.setState({ description: val, descriptionIsValid: valid });
  }

  validateDescription(n) {
    return n.length > 2;
  }

  onChangeAuthors(e) {
    e.persist();
    let val = e.target.value;
    let valid = this.validateAuthors(val);
    this.setState({ authors: val, authorsIsValid: valid });
  }

  validateAuthors(n) {
    return n.length > 2;
  }

  onChangePublishers(e) {
    e.persist();
    let val = e.target.value;
    let valid = this.validatePublishers(val);
    this.setState({ publishers: val, publishersIsValid: valid });
  }

  validatePublishers(n) {
    return n.length > 2;
  }

  onChangeImage(e) {
    e.preventDefault();
    let reader = new FileReader();
    let file = e.target.files[0];
    reader.onloadend = () => {
      this.setState({ image: reader.result, imageIsValid: true });
    };
    reader.readAsDataURL(file);
  }

  async handleAddBookSubmit(e) {
    e.preventDefault();
    let image = this.state.image.slice(23);

    if (
      this.state.nameIsValid &&
      this.state.originalNameIsValid &&
      this.state.isbnIsValid &&
      this.state.yearIsValid &&
      this.state.descriptionIsValid &&
      this.state.authorsIsValid &&
      this.state.publishersIsValid &&
      this.state.imageIsValid
    ) {
      let form = new FormData();
      form.append("name", this.state.name);
      form.append("originalName", this.state.originalName);
      form.append("isbn", this.state.isbn);
      form.append("year", this.state.year);
      form.append("description", this.state.description);
      form.append("imageUrl", image);

      let authors = this.state.authors.split(", ");
      form.append("authors", JSON.stringify(authors));
      let publishers = this.state.publishers.split(", ");
      form.append("publishers", JSON.stringify(publishers));

      let url = "api/book/addBook";
      let method = "POST";

      let response = await fetch(url, {
        method: method,
        mode: "cors",
        body: form,
      });

      let responseJson = "";

      if (response.ok) {
        responseJson = response.json();
        responseJson.then((results) => {
          alert(results.message);
        });
        window.location.replace("/Home");
      }
    } else {
      alert("Book - Not Valid Data!");
    }
  }

  renderAddBookModal() {
    let nameColor = this.state.nameIsValid ? "green" : "red";
    let originalNameColor = this.state.originalNameIsValid ? "green" : "red";
    let isbnColor = this.state.isbnIsValid ? "green" : "red";
    let yearColor = this.state.yearIsValid ? "green" : "red";
    let descriptionColor = this.state.descriptionIsValid ? "green" : "red";
    let authorsColor = this.state.authorsIsValid ? "green" : "red";
    let publishersColor = this.state.publishersIsValid ? "green" : "red";
    let imageColor = this.state.imageIsValid ? "green" : "red";

    return (
      <Card
        className="text-center border p-5 box-shadow"
        style={{ width: "auto", margin: "0 auto" }}
      >
        <Form onSubmit={this.handleAddBookSubmit}>
          <Form.Group controlId="formBasicName">
            <Form.Control
              className="mb-2 col-md-8 offset-md-2"
              type="text"
              placeholder="Name"
              onChange={this.onChangeName}
              style={{ borderColor: nameColor }}
            />
          </Form.Group>
          <Form.Group controlId="formBasicOriginalName">
            <Form.Control
              onChange={this.onChangeOriginalName}
              className="mb-2 col-md-8 offset-md-2"
              type="text"
              placeholder="Original Name"
              style={{ borderColor: originalNameColor }}
            />
          </Form.Group>
          <Form.Group controlId="formBasicISBN">
            <Form.Control
              onChange={this.onChangeISBN}
              className="mb-2 col-md-8 offset-md-2"
              type="text"
              placeholder="ISBN"
              style={{ borderColor: isbnColor }}
            />
          </Form.Group>
          <Form.Group controlId="formBasicYear">
            <Form.Control
              onChange={this.onChangeYear}
              className="mb-2 col-md-8 offset-md-2"
              type="number"
              min="1900"
              max="2020"
              step="1"
              placeholder="Year"
              style={{ borderColor: yearColor }}
            />
          </Form.Group>
          <Form.Group controlId="formBasicDescription">
            <Form.Control
              onChange={this.onChangeDescription}
              className="mb-2 col-md-8 offset-md-2"
              as="textarea"
              rows="3"
              placeholder="Description"
              style={{ borderColor: descriptionColor }}
            />
          </Form.Group>
          <Form.Group controlId="formBasicAuthors">
            <Form.Control
              onChange={this.onChangeAuthors}
              className="mb-2 col-md-8 offset-md-2"
              type="text"
              placeholder="Authors"
              style={{ borderColor: authorsColor }}
            />
          </Form.Group>
          <Form.Group controlId="formBasicPublishers">
            <Form.Control
              onChange={this.onChangePublishers}
              className="mb-2 col-md-8 offset-md-2"
              type="text"
              placeholder="Publishers"
              style={{ borderColor: publishersColor }}
            />
          </Form.Group>
          <Form.Group controlId="formBasicImage">
            <Form.Control
              onChange={this.onChangeImage}
              className="mb-2 col-md-8 offset-md-2"
              type="file"
              accept=".jpg"
              placeholder="Publishers"
              style={{ borderColor: imageColor }}
            />
          </Form.Group>
          <Button
            className="mb-2 col-md-4"
            style={{ boxShadow: "5px 5px 10px #cccccc" }}
            variant="primary"
            type="submit"
          >
            Add
          </Button>
        </Form>
      </Card>
    );
  }

  render() {
    return (
      <Tabs defaultActiveKey="BooksSettings" id="uncontrolled-tab-example">
        <Tab eventKey="BooksSettings" title="BooksSettings">
          <Card
            className="text-left border p-5 col-md-12 rounded flex-row flex-wrap mt-3 mb-2"
            style={{
              backgroundColor: "#EDE7F6",
              boxShadow: "5px 5px 10px #cccccc",
              margin: "0 auto",
              width: "100%",
            }}
          >
            <Row>
              <Form inline>
                <Button
                  onClick={this.modalAddBook}
                  className="mr-4"
                  style={{ boxShadow: "5px 5px 10px #cccccc" }}
                  variant="outline-primary"
                  size="md"
                >
                  Add Book
                </Button>
              </Form>
              <Form inline onSubmit={this.handleSubmitSearch}>
                <FormControl
                  type="text"
                  style={{ boxShadow: "5px 5px 10px #cccccc" }}
                  placeholder="Search"
                  className="mr-md-4"
                  onChange={this.onChangeSearch}
                />
                <Button
                  style={{ boxShadow: "5px 5px 10px #cccccc" }}
                  variant="outline-success"
                  type="submit"
                >
                  Search
                </Button>
              </Form>
            </Row>
          </Card>
          <BookSettingsTable data={this.state.allBooks} />
        </Tab>
        <Tab eventKey="Orders" title="Orders">
          <Order data={this.state.orders} statuses={this.state.statuses} />
        </Tab>
        <div>
          <Modal isOpen={this.state.modalAddBook}>
            <ModalHeader toggle={this.modalAddBook}>Add Book</ModalHeader>
            <ModalBody>{this.renderAddBookModal()}</ModalBody>
          </Modal>
        </div>
      </Tabs>
    );
  }
}
