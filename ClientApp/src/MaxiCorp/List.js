import React, { useState, useEffect, useCallback } from "react";
import axios from 'axios';
import { Card, Form } from "react-bootstrap";
import "./css.css";
import * as Icon from 'react-bootstrap-icons';
import { Link } from 'react-router-dom';

export default function List(props) {
  // let changeMode = props.action;
  let [listStaff, setlistStaff] = useState([]);
  const [textSearch, settextSearch] = useState("");
  const fetchData = useCallback((searchText) => {
    axios({
      "method": "GET",
      "url": "https://localhost:44311/api/Staff/GetByName/" + searchText,
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
  }, []);

  useEffect(() => {
    fetchData("");
  }, [fetchData]);
  const searchItems = (searchValue) => {
    settextSearch(searchValue);
  }
  const deleteStaff = (stfId) => {
    axios({
      "method": "DELETE",
      "url": "https://localhost:44311/api/Staff/Delete/" + stfId,
      "headers": {
        "content-type": "application/json"
      }
    })
      .then((response) => {
        let data = response.data;
        if (data.statusCode === 1) {
          alert("Delete staff success!");
        }
        else {
          alert("Delete staff fail!");
        }
        fetchData(textSearch);
      })
      .catch((error) => {
        console.log(error)
      })
  }
  const clickSearch = () => {
    fetchData(textSearch);
  }
  return (
    <div className="warp-content border-shadow">
      <div className="d-flex align-items-center justify-content-between app-bar">
        <div className="d-flex align-items-center justify-content-between app-bar">
          <Icon.Justify className="app-bar-icon" />
          <span className="date-text"> Danh sách nhân viên</span>
        </div>
        <div style={{ marginRight: "5px" }} className="d-flex align-items-center justify-content-between">
          <Form.Group style={{ marginBottom: "0px" }} controlId="textSearch">
            <Form.Control type="text" size="sm" placeholder="Search..." onChange={(e) => searchItems(e.target.value)} />
          </Form.Group>
          <Icon.Search className="app-bar-icon" style={{ marginLeft: "10px" }} onClick={() => clickSearch()} />

        </div>
      </div>
      <div className="warp-content-list">
        {listStaff.map(item => (
          <Card style={{ width: "90%", margin: "10px auto" }} key={item.id}>
            <Card.Header style={{ height: "55px", backgroundColor: "#8ec0e6" }}>
              <div className="d-flex align-items-center justify-content-between">
                <div><span className="item-vote-name">{item.stfName}</span></div>
                <div>
                  <span className="app-bar-icon" >
                    <Link to={"/Edit/" + item.id}>
                      <Icon.PencilSquare className="app-bar-icon-edit-fill" />
                    </Link>

                  </span>
                  <span className="app-bar-icon" >
                    <Icon.Trash className="app-bar-icon-edit-fill" onClick={() => window.confirm("Are you sure you wish to delete this item?") && deleteStaff(item.id)} />
                  </span>
                </div>
              </div>
            </Card.Header>
            <Card.Body style={{ backgroundColor: "#2c8fda", height: "fit-content" }}>
              <p>Mã nhân viên : {item.stfId}</p>
              <p>Chức vụ : {item.posName}</p>
              <p>Phòng ban : {item.deptName}</p>
              <p>Người quản lý : {item.manName}</p>
              <p>Ngày tạo :  {new Date(item.createTime).toDateString()}</p>
            </Card.Body>
          </Card>
        ))}


      </div>
    </div>
  );
}
