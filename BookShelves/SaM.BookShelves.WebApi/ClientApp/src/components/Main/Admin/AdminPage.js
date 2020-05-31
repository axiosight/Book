import React, { Component } from 'react';
import { Card, Row, Form, FormControl, Tabs, Tab, Button } from 'react-bootstrap';
import { OfficeTable } from './OfficeTable';
import { LibrariensTable } from './LibrariensTable';
import { Modal, ModalHeader, ModalBody } from 'reactstrap';

export class AdminPage extends Component {
    static displayName = AdminPage.name;

    constructor(props) {
        super(props);

        this.state = {
            offices: [],
            librariens: [],
            modalAddOffice: false,
            officeN: "", officeNameIsValid: false,
            officeA: "", officeAdressIsValid: false,

            modalAddLibrarian: false,
            libEmail: "", libEmailIsValid: false,
            libPassword: "", libPasswordIsValid: false,
            libName: "", libNameIsValid: false,
            libSurname: "", libSurnameIsValid: false,
            libFloor: 0, libFloorIsValid: false,
            libRoom: 0, libRoomIsValid: false,

            searchTermOffice: "",
        };

        this.modalAddOffice = this.modalAddOffice.bind(this);
        this.modalAddLibrarian = this.modalAddLibrarian.bind(this);

        this.onChangeEmail = this.onChangeEmail.bind(this);
        this.onChangePassword = this.onChangePassword.bind(this);
        this.onChangeLibName = this.onChangeLibName.bind(this);
        this.onChangeLibSurname = this.onChangeLibSurname.bind(this);
        this.onChangeLibFloor = this.onChangeLibFloor.bind(this);
        this.onChangeLibRoom = this.onChangeLibRoom.bind(this);

        this.onChangeName = this.onChangeName.bind(this);
        this.onChangeAdress = this.onChangeAdress.bind(this);

        this.onChangeSearchOffice = this.onChangeSearchOffice.bind(this);
        // this.AddLibrarianSubmit = this.AddLibrarianSubmit(this);
        this.handleAddOfficeSubmit = this.handleAddOfficeSubmit.bind(this);

        this.handleSubmitSearchOffice = this.handleSubmitSearchOffice.bind(this);
    }

    validateEmail(email) {
        var re = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        return re.test(email);
    }

    validatePassword(password) {
        return password.length > 0;
    }

    validateNum(num) {
        return num > 0;
    }

    validateName(n) {
        return n.length > 2;
    }

    validateAdress(adress) {
        return adress.length > 2;
    }

    onChangeSearchOffice(e) {
        e.persist();
        let val = e.target.value;
        this.setState({ searchTermOffice: val });
    }

    onChangeEmail(e) {
        e.persist();
        let val = e.target.value;
        let valid = this.validateEmail(val);
        this.setState({ libEmail: val, libEmailIsValid: valid });
    }

    onChangePassword(e) {
        e.persist();
        let val = e.target.value;
        let valid = this.validatePassword(val);
        this.setState({ libPassword: val, libPasswordIsValid: valid });
    }

    onChangeLibName(e) {
        e.persist();
        let val = e.target.value;
        let valid = this.validateName(val);
        this.setState({ libName: val, libNameIsValid: valid });
    }

    onChangeLibSurname(e) {
        e.persist();
        let val = e.target.value;
        let valid = this.validateName(val);
        this.setState({ libSurame: val, libSurnameIsValid: valid });
    }

    onChangeLibFloor(e) {
        e.persist();
        let val = e.target.value;
        let valid = this.validateNum(val);
        this.setState({ libFloor: val, libFloorIsValid: valid });
    }

    onChangeLibRoom(e) {
        e.persist();
        let val = e.target.value;
        let valid = this.validateNum(val);
        this.setState({ libRoom: val, libRoomIsValid: valid });
    }

    onChangeName(e) {
        e.persist();
        let val = e.target.value;
        console.log(val);
        let valid = this.validateName(val);
        console.log(valid);
        this.setState({ officeN: val, officeNameIsValid: valid });
    }

    onChangeAdress(e) {
        e.persist();
        let val = e.target.value;
        console.log(val);
        let valid = this.validateAdress(val);
        console.log(valid);
        this.setState({ officeA: val, officeAdressIsValid: valid });
    }

    modalAddOffice() {
        this.setState({
            modalAddOffice: !this.state.modalAddOffice
        });
    }

    modalAddLibrarian() {
        this.setState({
            modalAddLibrarian: !this.state.modalAddLibrarian
        });
    }

    async loadData() {
        let url = "api/admin/getAllOffices";

        let response = await fetch(url);
        if (response.ok) {
            let responseJson = response.json();

            responseJson.then(results => {
                this.setState({
                    offices: results
                });
            });
        }
    }

    // AddLibrarianSubmit(e) {

    //     if (this.state.libEmailIsValid === true && this.state.libPasswordIsValid === true && this.state.libNameIsValid === true && this.state.libSurnameIsValid === true && this.state.libFloorIsValid === true && this.state.libRoomIsValid === true) {

    //         let form = new FormData();
    //         form.append('email', this.state.libEmail);
    //         form.append('password', this.state.libPassword);
    //         form.append('name', this.state.libName);
    //         form.append('surname', this.state.libSurname);
    //         form.append('floor', this.state.libFloor);
    //         form.append('room', this.state.libRoom);

    //         let url = "api/admin/addLibrarian";
    //         let method = 'POST';

    //         let response = fetch(url, {
    //             method: method,
    //             mode: 'cors',
    //             body: form
    //         });

    //         let responseJson = "";

    //         if (response.ok) {
    //             responseJson = response.json();
    //             responseJson.then(results => {
    //                 alert(results.message);
    //             });
    //             window.location.replace("/Home");
    //         }
    //     }
    //     else {
    //         alert("Lib - Not Valid Data!");
    //     }
    // }

    async handleAddOfficeSubmit(e) {
        e.preventDefault();

        if (this.state.officeNameIsValid === true && this.state.officeAdressIsValid === true) {

            let form = new FormData();
            form.append('name', this.state.officeN);
            form.append('adress', this.state.officeA);

            let url = "api/admin/addOffice";
            let method = 'POST';

            let response = await fetch(url, {
                method: method,
                mode: 'cors',
                body: form
            });

            let responseJson = "";

            if (response.ok) {
                responseJson = response.json();
                responseJson.then(results => {
                    alert(results.message);
                });
                window.location.replace("/Home");
            }
        }
        else {
            alert("Office - Not Valid Data!");
        }
    }

    renderAddOfficeModal() {
        let nameColor = this.state.officeNameIsValid === true ? "green" : "red";
        let surnameColor = this.state.officeAdressIsValid === true ? "green" : "red";

        return (
            <Card className="text-center border p-5 box-shadow" style={{ width: 'auto', margin: '0 auto' }}>
                <Form onSubmit={this.handleAddOfficeSubmit}>
                    <Form.Group controlId="formBasicName">
                        <Form.Control onChange={this.onChangeName} className="mb-2 col-md-8 offset-md-2" type="text" placeholder="Name" style={{ borderColor: nameColor }} />
                    </Form.Group>
                    <Form.Group controlId="formBasicSurname">
                        <Form.Control onChange={this.onChangeAdress} className="mb-2 col-md-8 offset-md-2" type="text" placeholder="Adress" style={{ borderColor: surnameColor }} />
                    </Form.Group>
                    <Button className="mb-2 col-md-4" style={{ boxShadow: '5px 5px 10px #cccccc' }} variant="primary" type="submit">Add</Button>
                </Form>
            </Card>
        );
    }

    renderAddLibModal() {
        let emailColor = this.state.libEmailIsValid === true ? "green" : "red";
        let passwordColor = this.state.libPasswordIsValid === true ? "green" : "red";
        let nameColor = this.state.libNameIsValid === true ? "green" : "red";
        let surnameColor = this.state.libSurnameIsValid === true ? "green" : "red";
        let floorColor = this.state.libFloorIsValid === true ? "green" : "red";
        let roomColor = this.state.libRoomIsValid === true ? "green" : "red";

        return (
            <Card className="text-center border p-5 box-shadow" style={{ width: 'auto', margin: '0 auto' }}>
                <Form>
                    <Form.Group controlId="formBasisacName">
                        <Form.Control onChange={this.onChangeEmail} className="mb-2 col-md-8 offset-md-2" type="email" placeholder="Email" style={{ borderColor: emailColor }} />
                    </Form.Group>
                    <Form.Group controlId="formBasisacName">
                        <Form.Control onChange={this.onChangePassword} className="mb-2 col-md-8 offset-md-2" type="password" placeholder="Password" style={{ borderColor: passwordColor }} />
                    </Form.Group>
                    <Form.Group controlId="formBasicName">
                        <Form.Control onChange={this.onChangeLibName} className="mb-2 col-md-8 offset-md-2" type="text" placeholder="Name" style={{ borderColor: nameColor }} />
                    </Form.Group>
                    <Form.Group controlId="formBassaicSurname">
                        <Form.Control onChange={this.onChangeLibSurname} className="mb-2 col-md-8 offset-md-2" type="text" placeholder="Surname" style={{ borderColor: surnameColor }} />
                    </Form.Group>
                    <Form.Group controlId="fsormBassicSurname">
                        <Form.Control onChange={this.onChangeLibFloor} className="mb-2 col-md-8 offset-md-2" type="number" placeholder="Floor" style={{ borderColor: floorColor }} />
                    </Form.Group>
                    <Form.Group controlId="formdBassicSurnasme">
                        <Form.Control onChange={this.onChangeLibRoom} className="mb-2 col-md-8 offset-md-2" type="number" placeholder="Room" style={{ borderColor: roomColor }} />
                    </Form.Group>
                    <Button className="mb-2 col-md-4" style={{ boxShadow: '5px 5px 10px #cccccc' }} variant="primary" type="submit">Add</Button>
                </Form>
            </Card>
        );
    }

    async loadLibData() {
        let url = "api/admin/getAllLibrariens";

        let response = await fetch(url);
        if (response.ok) {
            let responseJson = response.json();

            responseJson.then(results => {
                this.setState({
                    librariens: results
                });
            });
        }
    }

    async componentDidMount() {
        await this.loadData();
        await this.loadLibData();
    }

    async handleSubmitSearchOffice(e) {
        e.preventDefault();
        let form = new FormData();
            form.append('searchTermOffice', this.state.searchTermOffice);

            debugger;
            let url = "api/admin/searchOffice";
            let method = 'POST';

            let response = await fetch(url, {
                method: method,
                mode: 'cors',
                body: form
            });

            if (response.ok) {
                if (response.ok) {
                    let responseJson = response.json();
                    responseJson.then(results => {
                        this.setState({
                            offices: results
                        });
                    });
                }
                //window.location.replace("/Home");
            }
    }

    render() {
        return (
            <div>
                <Tabs defaultActiveKey="Offices" id="uncontrolled-tab-example">
                    <Tab eventKey="Offices" title="Offices">
                        <Card className="text-left border p-5 col-md-12 rounded flex-row flex-wrap mt-3 mb-2" style={{ backgroundColor: '#EDE7F6', boxShadow: '5px 5px 10px #cccccc', margin: '0 auto', width: '100%' }}>
                            <Row>
                                <Form inline>
                                    <Button onClick={this.modalAddOffice} className="mr-4" style={{ boxShadow: '5px 5px 10px #cccccc' }} variant="outline-primary" size="md">Add Office</Button>
                                </Form>
                                <Form inline onSubmit={this.handleSubmitSearchOffice}>
                                    <FormControl type="text" style={{ boxShadow: '5px 5px 10px #cccccc' }} placeholder="Search" className="mr-md-4" onChange={this.onChangeSearchOffice} />
                                    <Button style={{ boxShadow: '5px 5px 10px #cccccc' }} variant="outline-success" type="submit">Search</Button>
                                </Form>
                            </Row>
                        </Card>
                        <OfficeTable data={this.state.offices} />
                    </Tab>
                    <Tab eventKey="Librariens" title="Librariens">
                        <Card className="text-left border p-5 col-md-12 rounded flex-row flex-wrap mt-3 mb-2" style={{ backgroundColor: '#EDE7F6', boxShadow: '5px 5px 10px #cccccc', margin: '0 auto', width: '100%' }}>
                            <Row>
                                <Form inline>
                                    <Button onClick={this.modalAddLibrarian} className="mr-4" style={{ boxShadow: '5px 5px 10px #cccccc' }} variant="outline-primary" size="md">Add Librarian</Button>
                                </Form>
                                <Form inline>
                                    <FormControl type="text" style={{ boxShadow: '5px 5px 10px #cccccc' }} placeholder="Search" className="mr-md-4" onChange={this.onChangeSearch} />
                                    <Button style={{ boxShadow: '5px 5px 10px #cccccc' }} variant="outline-success" type="submit">Search</Button>
                                </Form>
                            </Row>
                        </Card>
                        <LibrariensTable libdata={this.state.librariens} />
                    </Tab>
                    <div>
                        <Modal isOpen={this.state.modalAddOffice}>
                            <ModalHeader toggle={this.modalAddOffice}>Add Office</ModalHeader>
                            <ModalBody>
                                {this.renderAddOfficeModal()}
                            </ModalBody>
                        </Modal>
                    </div>
                    <div>
                        <Modal isOpen={this.state.modalAddLibrarian}>
                            <ModalHeader toggle={this.modalAddLibrarian}>Add Librarian</ModalHeader>
                            <ModalBody>
                                {this.renderAddLibModal()}
                            </ModalBody>
                        </Modal>
                    </div>
                </Tabs>
            </div>
        );
    }
}