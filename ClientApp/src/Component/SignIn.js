import React from "react";
import { Card, Button, Form } from 'react-bootstrap';
import './css.css';

export default function SignIn(props) {
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
  return (
    <div className="warp-content">
      <Card>
        <Form onSubmit={onSubmit}>
          <Card.Body style={{ backgroundColor: 'rgb(44 143 218)' }}>
            <Card.Title>Login</Card.Title>

            <Form.Group className="mb-3" controlId="formEmail">
              <Form.Control type="email" placeholder="Email" required />
            </Form.Group>

            <Form.Group className="mb-3" controlId="formPassword">
              <Form.Control type="password" placeholder="Password" required />
            </Form.Group>

          </Card.Body>
          <Card.Footer style={{ backgroundColor: 'rgb(99 175 232)' }}>
            <div className="d-flex justify-content-between">
              <Button variant="danger" type="Submit">
                Submit
              </Button>
              <Button variant="link" type="Button" onClick={() => {changeMode('login')} } style={{ color: 'rgb(109 115 119)' }}>Register</Button>
            </div>
          </Card.Footer>
        </Form>
      </Card>
    </div>
  );
}
