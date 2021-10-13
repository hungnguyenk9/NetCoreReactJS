import React, { useState, useEffect } from "react";
import { Card, Button, Form } from 'react-bootstrap';
import './css.css';
import axios from 'axios';

export default function Add(props) {
  let [listStaff, setlistStaff] = useState([]);
  useEffect(() => {
    getListMan();
  }, []);
  function onSubmit(e) {
    e.preventDefault();
    let datasent = {
      "stfName": e.target["StfName"].value,
      "deptId": parseInt(e.target["DeptId"].value),
      "posId": parseInt(e.target["PosId"].value),
      "manId": parseInt(e.target["ManId"].value),
    };
    const headers = {
      "content-type": "application/json"
    };
    axios.post("https://localhost:44311/api/Staff/Add", datasent, { headers })
      .then(
        (response) => {
          this.setState({ articleId: response.data.id });
        })
      .catch((error) => {
        console.log(error)
      });
  }
  const getListMan = () => {
    axios({
      "method": "GET",
      "url": "https://localhost:44311/api/Staff/GetListMan/0",
      "headers": {
        "content-type": "application/json"
      }
    })
      .then((response) => {
        let data = response.data;
        if (data.statusCode === 1) {
          setlistStaff(data.data);
        }
        else {
          setlistStaff([]);
        }
      })
      .catch((error) => {
        console.log(error)
      })
  }
  return (
    <div className="warp-content">
      <Card>
        <Form onSubmit={onSubmit}>
          <Card.Body style={{ backgroundColor: "rgb(44 143 218)" }}>
            <Card.Title style={{ color: "white" }}>Thêm nhân viên</Card.Title>
            <Form.Group className="mb-3" controlId="StfName">
              <Form.Label>Tên nhân viên</Form.Label>
              <Form.Control type="text" placeholder="Staff Name" required />
            </Form.Group>

            <Form.Group className="mb-3" controlId="DeptId">
              <Form.Label>Phòng ban</Form.Label>
              <Form.Control as="select">
                <option value={null}>----</option>
                <option value="1">Phòng IT</option>
                <option value="2">Phòng Kế Toán</option>
              </Form.Control>
            </Form.Group>
            <Form.Group className="mb-3" controlId="PosId">
              <Form.Label>Chức vụ</Form.Label>
              <Form.Control as="select">
                <option value={null}>----</option>
                <option value="4">Nhân Viên</option>
                <option value="3">Trưởng Nhóm</option>
                <option value="2">Quản Lý</option>
                <option value="1">Giám Đốc</option>
              </Form.Control>
            </Form.Group>
            <Form.Group className="mb-3" controlId="ManId">
              <Form.Label>Quản lý trực tiếp</Form.Label>
              <Form.Control as="select">
                <option value={null}>----</option>
                {listStaff.map(item => (
                  <option value={item.id} key={item.id}>{item.stfName}</option>
                ))}

              </Form.Control>
            </Form.Group>
          </Card.Body>
          <Card.Footer style={{ backgroundColor: "rgb(99 175 232)" }}>
            <div className="d-flex justify-content-between">
              <Button variant="danger" type="Submit">
                Thêm mới
              </Button>
            </div>
          </Card.Footer>
        </Form>
      </Card>
    </div>
  );
}
