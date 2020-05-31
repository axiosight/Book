import React, { Component } from 'react';
import { Card, Table, Form, FormControl, Button } from 'react-bootstrap';
import { Modal, ModalHeader, ModalBody } from 'reactstrap';

class Item extends Component {

    constructor(props) {
        super(props);

        this.state = {
            modalUpdateOffice: false,
            officeId: this.props.officeId,
            officeN: this.props.officeName, officeNameIsValid: false,
            officeA: this.props.officeAdress, officeAdressIsValid: false,
        }

        this.onChangeName = this.onChangeName.bind(this);
        this.onChangeAdress = this.onChangeAdress.bind(this);

        this.handleDeleteOffice = this.handleDeleteOffice.bind(this);
        this.modalUpdateOffice = this.modalUpdateOffice.bind(this);
    }

    modalUpdateOffice() {
        this.setState({
            modalUpdateOffice: !this.state.modalUpdateOffice
        });
    }

    validateName(n) {
        return n.length > 2;
    }

    validateAdress(adress) {
        return adress.length > 2;
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

    renderUpdateOfficeModal() {
        let nameColor = this.state.officeNameIsValid === true ? "green" : "lightGray";
        let adressColor = this.state.officeAdressIsValid === true ? "green" : "lightGray";

        return (
            <Card className="text-center border p-5 box-shadow" style={{ width: 'auto', margin: '0 auto' }}>
                <Form onSubmit={this.handleUpdateOfficeSubmit}>
                    <Form.Group controlId="formBasicName">
                        <Form.Control onChange={this.onChangeName} value={this.state.officeN} className="mb-2 col-md-8 offset-md-2" type="text" placeholder="Name" style={{ borderColor: nameColor }} />
                    </Form.Group>
                    <Form.Group controlId="formBasicSurname">
                        <Form.Control onChange={this.onChangeAdress} value={this.state.officeA} className="mb-2 col-md-8 offset-md-2" type="text" placeholder="Adress" style={{ borderColor: adressColor }} />
                    </Form.Group>
                    <Button className="mb-2 col-md-4" style={{ boxShadow: '5px 5px 10px #cccccc' }} variant="primary" type="submit">Update</Button>
                </Form>
            </Card>
        );
    }

    async handleUpdateSubmit(e) {
        e.preventDefault();

        debugger;
        if (this.state.officeNameIsValid === true && this.state.officeAdressIsValid === true) {

            let form = new FormData();
            form.append('id', this.state.officeId);
            form.append('name', this.state.officeN);
            form.append('adress', this.state.officeA);

            let url = "api/admin/updateOffice";
            let method = 'POST';

            let response = await fetch(url, {
                method: method,
                mode: 'cors',
                body: form
            });

            if (response.ok) {
                window.location.replace("/Home");
            }
        }
        else{
            alert("Not Valid!")
        }
    }

    handleDeleteOffice() {
        let url = `api/admin/deleteOffice/${this.props.officeId}`;
        // alert(url);
        let method = 'DELETE';
        // debugger;
        let response = fetch(url, {
            method: method,
            mode: 'cors'
        });
        if (response.ok) {
            alert("Delete!");
            window.location.replace("/Home");
        }
        else {
            alert("Delete!");
            window.location.replace("/Home");
        }
    }

    render() {
        return (
            <tr>
                <td className="text-center">{this.props.officeName}</td>
                <td className="text-center">{this.props.officeAdress}</td>
                <td className="text-center">
                    <Button onClick={this.modalUpdateOffice} className="m-2" style={{ boxShadow: '5px 5px 10px #cccccc' }} variant="outline-info" size="sm">Update</Button>
                    <Button onClick={this.handleDeleteOffice} className="m-2" style={{ boxShadow: '5px 5px 10px #cccccc' }} variant="outline-danger" size="sm">Delete</Button>
                    <Modal isOpen={this.state.modalUpdateOffice}>
                        <ModalHeader toggle={this.modalUpdateOffice}>Update Office</ModalHeader>
                        <ModalBody>
                            {this.renderUpdateOfficeModal()}
                        </ModalBody>
                    </Modal>
                </td>
            </tr>
        );
    }
}

export class OfficeTable extends Component {
    static displayName = OfficeTable.name;
    render() {
        return (
            <Table striped bordered hover responsive className="mt-2">
                <thead>
                    <tr className="text-center" style={{ boxShadow: '5px 5px 10px #cccccc' }}>
                        <th className="text-center">Office Name</th>
                        <th className="text-center">Office Adress</th>
                        <th className="text-center"></th>
                    </tr>
                </thead>
                <tbody>
                    {
                        this.props.data.map(function (item) {
                            return <Item key={item.id} officeId={item.id} officeName={item.name} officeAdress={item.adress} />
                        })
                    }
                </tbody>
            </Table>

        );
    }
}