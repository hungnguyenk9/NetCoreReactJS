import React, { useState, useEffect } from "react";
import { Card, Button, Form } from 'react-bootstrap';
import './css.css';
import axios from 'axios';

export default function Edit({ history, match }) {
  const { id } = match.params;
  let [listStaff, setlistStaff] = useState([]);
  let stf = {
    id: "",
    stfName: "",
    deptId: 0,
    posId: 0,
    manId: 0
  };
  let [staff, setstaff] = useState(stf);
  useEffect(() => {
    getById(id);
    getListMan(id);

  }, [id]);
  function onSubmit(e) {
    e.preventDefault();
    const headers = {
      "content-type": "application/json"
    };
    axios.put("https://localhost:44311/api/Staff/Update", staff, { headers })
      .then(
        (response) => {
          let data = response.data;
          if (data.statusCode === 1) {
            alert(data.msg);
          }
          else
          {
            alert(data.msg);
          }
        })
      .catch((error) => {
        console.log(error)
      });
  }
  const getListMan = (id = 0) => {
    axios({
      "method": "GET",
      "url": "https://localhost:44311/api/Staff/GetListMan/" + id,
      "headers": {
        "content-type": "application/json"
      }
    })
      .then((response) => {
        let data = response.data;
        if (data.statusCode === 1) {
          setlistStaff(data.data);
        }

      })
      .catch((error) => {
        console.log(error)
      })
  }
  const getById = (id) => {
    axios({
      "method": "GET",
      "url": "https://localhost:44311/api/Staff/GetById/" + id,
      "headers": {
        "content-type": "application/json"
      }
    })
      .then((response) => {
        let data = response.data;
        if (data.statusCode === 1) {
          setstaff(data.data);
        }
        else {
          alert(data.msg);
        }
      })
      .catch((error) => {
        console.log(error);
      })
  }
  const handleChange = (event) => {
    let { name, value } = event.target
    setstaff({ ...staff, [name]: value });
  }
  return (
    <div className="warp-content">
      <Card>
        <Form onSubmit={onSubmit}>
          <Card.Body style={{ backgroundColor: "rgb(44 143 218)" }}>
            <Card.Title style={{ color: "white" }}>Chỉnh sửa thông tin</Card.Title>
            <Form.Group className="mb-3" controlId="StfName">
              <Form.Label>Tên nhân viên</Form.Label>
              <Form.Control type="text" placeholder="Staff Name" name="stfName" value={staff.stfName} required onChange={handleChange} />
            </Form.Group>

            <Form.Group className="mb-3" controlId="DeptId">
              <Form.Label>Phòng ban</Form.Label>
              <Form.Control as="select" value={staff.deptId} name="deptId" onChange={handleChange}>
                <option value={null}>----</option>
                <option value="1">Phòng IT</option>
                <option value="2">Phòng Kế Toán</option>
              </Form.Control>
            </Form.Group>
            <Form.Group className="mb-3" controlId="PosId">
              <Form.Label>Chức vụ</Form.Label>
              <Form.Control as="select" value={staff.posId} name="posId" onChange={handleChange}>
                <option value={null}>----</option>
                <option value="4">Nhân Viên</option>
                <option value="3">Trưởng Nhóm</option>
                <option value="2">Quản Lý</option>
                <option value="1">Giám Đốc</option>
              </Form.Control>
            </Form.Group>
            <Form.Group className="mb-3" controlId="ManId">
              <Form.Label>Quản lý trực tiếp</Form.Label>
              <Form.Control as="select" value={staff.manId} name="manId" onChange={handleChange}>
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
                Cập nhật
              </Button>
            </div>
          </Card.Footer>
        </Form>
      </Card>
    </div>
  );
}
