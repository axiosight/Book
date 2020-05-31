import React, { Component } from 'react';
import { Table, Button } from 'react-bootstrap';

class Item extends Component {

    constructor(props) {
        super(props);

        this.handleDeleteLibrarian = this.handleDeleteLibrarian.bind(this);
    }

    handleDeleteLibrarian() {
        let url = `api/admin/deleteLibrarian/${this.props.libId}`;
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
                <td className="text-center">{this.props.libEmail}</td>
                <td className="text-center">{this.props.libName} {this.props.libSurname}</td>
                <td className="text-center">+{this.props.libMobile}</td>
                <td className="text-center">{this.props.libFloor}</td>
                <td className="text-center">{this.props.libRoom}</td>
                <td className="text-center">{this.props.libOfficeName}</td>
                <td className="text-center">
                    <Button className="m-2" style={{ boxShadow: '5px 5px 10px #cccccc' }} variant="outline-danger" size="sm">Delete</Button>
                </td>
            </tr>
        );
    }
}

export class LibrariensTable extends Component {
    static displayName = LibrariensTable.name;
    render() {
        return (
            <Table striped bordered hover responsive className="mt-2">
                <thead>
                    <tr className="text-center" style={{ boxShadow: '5px 5px 10px #cccccc' }}>
                        <th className="text-center">Email</th>
                        <th className="text-center">Name</th>
                        <th className="text-center">Mobile</th>
                        <th className="text-center">Floor</th>
                        <th className="text-center">Room</th>
                        <th className="text-center">Office</th>
                        <th className="text-center"></th>
                    </tr>
                </thead>
                <tbody>
                    {
                        this.props.libdata.map(function (item) {
                            return <Item key={item.id} libId={item.id} libEmail={item.email} libName={item.name} libSurname={item.surname} libMobile={item.mobile} libFloor={item.floor} libRoom={item.room} libOfficeId={item.officeId} libOfficeName={item.officeName}/>
                        })
                    }
                </tbody>
            </Table>
        );
    }
}