import React, { useState, useEffect, useRef } from "react";
import { Card, Button, Form } from "react-bootstrap";
import "./css.css";
import * as Icon from 'react-bootstrap-icons';
import $ from 'jquery';
export default function List(props) {
  // let changeMode = props.action;
  const [listStaff, setlistStaff] = useState([]);

  useEffect(() => {
    async function fetchData() {
      let result = await getData()
      setlistStaff(result);
    }
    fetchData();

  });

  async function getData() {
    const requestOptions = {
      method: "GET",
      headers: { "Content-Type": "application/json" }
    };
    let response = await fetch("https://localhost:44311/api/Staff/GetListMan/0", requestOptions);
    let data = await response.json();
    if (data.statusCode === 1) {
      return data.data;
    }
    else {
      return [];
    }
  }
  return (
    <div className="warp-content border-shadow">
      <div className="d-flex align-items-center justify-content-between app-bar">
        <div className="d-flex align-items-center justify-content-between app-bar">
          <Icon.Justify className="app-bar-icon" />
          <span className="date-text"> Danh sách nhân viên</span>

        </div>
        <div><Icon.PersonCircle className="app-bar-icon-persom" /></div>
      </div>
      <div>
        {listStaff.map(item => (
          <Card style={{ width: "90%", margin: "10px auto" }} key={item.id}>
            <Card.Header style={{ height: "55px", backgroundColor: "#8ec0e6" }}>
              <div className="d-flex align-items-center justify-content-between">
                <div><span className="item-vote-name">Staff Name : {item.stfName}</span></div>
              </div>
            </Card.Header>
            <Card.Body style={{ backgroundColor: "#2c8fda", height: "200px" }}>
                <p>Chức vụ : {item.posName}</p>
                <p>Phòng ban : {item.deptName}</p>
                <p>Người quản lý : {item.manName}</p>
                <p>Ngày tạo :  {item.createTime}</p>
            </Card.Body>
          </Card>
        ))}


      </div>
    </div>
  );
}
