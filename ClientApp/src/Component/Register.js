import React from "react";
import { Card, Button, Form } from 'react-bootstrap';
import './css.css';


export default function Register(props) {
  let changeMode = props.action;
  let isConfirm = true;
  async function onSubmit(e) {
    e.preventDefault();
    if (e.target["formPassword"].value !== e.target["formConfirmPassword"].value) {
      isConfirm = false;
      alert(isConfirm);
      return;
    }
    let datasent = {
      "email": e.target["formEmail"].value,
      "password": e.target["formPassword"].value
    };

    const requestOptions = {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(datasent)
    };
    let response = await fetch("https://localhost:44311/api/User/Register", requestOptions);
    let data = await response.json();
    if (data.statusCode === 1) {
      localStorage.setItem("sample-vote", JSON.stringify(data.data));
      alert("Register success!");
      changeMode("listVote");
    }
    else {
      alert(data.msg);
    }
  }
  return (
    <div className="warp-content">
      <Card>
        <Form onSubmit={onSubmit}>
          <Card.Body style={{ backgroundColor: 'rgb(44 143 218)' }}>
            <Card.Title>Register</Card.Title>

            <Form.Group className="mb-3" controlId="formEmail">
              <Form.Control type="email" placeholder="Email" required />
            </Form.Group>

            <Form.Group className="mb-3" controlId="formPassword">
              <Form.Control type="password" placeholder="Password" required />
            </Form.Group>

            <Form.Group className="mb-3" controlId="formConfirmPassword">
              <Form.Control type="password" placeholder="Confirm Password" required />
            </Form.Group>

          </Card.Body>
          <Card.Footer style={{ backgroundColor: 'rgb(99 175 232)' }}>
            <div className="d-flex justify-content-between">
              <Button variant="danger" type="Submit"> Register</Button>
              <Button variant="link" type="Button" onClick={() => { changeMode('login') }} style={{ color: 'rgb(109 115 119)' }}>Signin</Button>
            </div>
          </Card.Footer>
        </Form>
      </Card>
    </div>
  );
}

