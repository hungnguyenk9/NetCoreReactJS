import React, { useState, useEffect,useCallback } from "react";
import axios from 'axios';
import { Card, Button, Form, InputGroup, FormControl } from "react-bootstrap";
import "./css.css";
import * as Icon from 'react-bootstrap-icons';
export default function List(props) {
  // let changeMode = props.action;
  let [listStaff, setlistStaff] = useState([]);
  const [textSearch, settextSearch] = useState("");
  const fetchData = useCallback(() => {
    axios({
      "method": "GET",
      "url": "https://localhost:44311/api/Staff/GetByName/" + textSearch,
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
  }, [textSearch])

  useEffect(() => {
    fetchData();
  },[fetchData]);
  const searchItems = (searchValue) => {
    settextSearch(searchValue);
  }

  return (
    <div className="warp-content border-shadow">
      <div className="d-flex align-items-center justify-content-between app-bar">
        <div className="d-flex align-items-center justify-content-between app-bar">
          <Icon.Justify className="app-bar-icon" />
          <span className="date-text"> Danh sách nhân viên</span>
        </div>
        <div style={{ marginRight: "5px" }}>
          <Form.Group style={{marginBottom:"0px"}} controlId="textSearch">
            <Form.Control type="text" size="sm" placeholder="Search..." onChange={(e) => searchItems(e.target.value)}/>
          </Form.Group>
        </div>
      </div>
      <div>
        {listStaff.map(item => (
          <Card style={{ width: "90%", margin: "10px auto" }} key={item.id}>
            <Card.Header style={{ height: "55px", backgroundColor: "#8ec0e6" }}>
              <div className="d-flex align-items-center justify-content-between">
                <div><span className="item-vote-name">{item.stfName}</span></div>
                <div>
                  <span className="app-bar-icon" >
                    <Icon.PencilSquare className="app-bar-icon-edit-fill" />
                  </span>
                  <span className="app-bar-icon" >
                    <Icon.Trash className="app-bar-icon-edit-fill" />
                  </span>
                </div>
              </div>
            </Card.Header>
            <Card.Body style={{ backgroundColor: "#2c8fda", height: "200px" }}>
              <p>Chức vụ : {item.posName}</p>
              <p>Phòng ban : {item.deptName}</p>
              <p>Người quản lý : {item.manName}</p>
              <p>Ngày tạo :  {new Date(item.createTime ).toDateString()}</p>
            </Card.Body>
          </Card>
        ))}


      </div>
    </div>
  );
}
