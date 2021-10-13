import React from "react";
import { Card, Button, Form } from 'react-bootstrap';
import './css.css';

export default function Add(props) {
  let changeMode = props.action;

  async function onSubmit(e) {
    e.preventDefault();
    let datasent = {
      "email": e.target["formEmail"].value,
      "password": e.target["formPassword"].value
    };
    const requestOptions = {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(datasent)
    };
    let response = await fetch("https://localhost:44311/api/User/SignIn", requestOptions);
    let data = await response.json();
    if (data.statusCode === 1) {
      localStorage.setItem("sample-vote", JSON.stringify(data.data));
      alert("Login success!");
      changeMode("listVote");
    }
    else {
      alert("Wrong password or email!");
    }
  }
  function onChangeFunc(optionSelected) {
    const name = this.name;
    const value = optionSelected.value;
    const label = optionSelected.label;
  }
  return (
    <div className="warp-content">
      <Card>
        <Form onSubmit={onSubmit}>
          <Card.Body style={{ backgroundColor: 'rgb(44 143 218)' }}>
            <Card.Title>Add Staff</Card.Title>

            <Form.Group className="mb-3" controlId="stfName">
              <Form.Control type="text" placeholder="Staff Name" required />
            </Form.Group>

            <Form.Group className="mb-3" controlId="DeptId">
              <Form.Control as="select">
                <option value="1">Phòng IT</option>
                <option value="2">Phòng Kế Toán</option>
              </Form.Control>
            </Form.Group>
            <Form.Group className="mb-3" controlId="PosId">
              <Form.Control as="select">
                <option value="1">Giám Đốc</option>
                <option value="2">Quản Lý</option>
                <option value="3">Trưởng Nhóm</option>
                <option value="4">Nhân Viên</option>
              </Form.Control>
            </Form.Group>
            <Form.Group className="mb-3" controlId="ManId">
              <Form.Control as="select">
                <option value="1">Dictamen</option>
                <option value="2">Constancia</option>
                <option value="3">Complemento</option>
              </Form.Control>
            </Form.Group>
          </Card.Body>
          <Card.Footer style={{ backgroundColor: 'rgb(99 175 232)' }}>
            <div className="d-flex justify-content-between">
              <Button variant="danger" type="Submit">
                Submit
              </Button>
            </div>
          </Card.Footer>
        </Form>
      </Card>
    </div>
  );
}
