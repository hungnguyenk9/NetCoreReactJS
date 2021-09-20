import React, { useState, useEffect, useRef } from "react";
import { Card, Button, Form } from "react-bootstrap";
import "./css.css";
import * as Icon from 'react-bootstrap-icons';
import $ from 'jquery';
export default function ListVote(props) {
  // let changeMode = props.action;
  const [listVote, setlistVote] = useState([]);
  const [pageNum, setPageNume] = useState(1);
  const [pageSize, setPageSize] = useState(20);
  const myRefname= useRef(null);
  useEffect(() => {
    async function fetchData() {
      let result = await getData("2021-09-18", pageNum, pageSize)
      setlistVote(result);
    }
    fetchData();

  }, [pageNum, pageSize]);

  async function getData(date, pageNum, pageSize) {
    const requestOptions = {
      method: "GET",
      headers: { "Content-Type": "application/json" }
    };
    let response = await fetch("https://localhost:44311/api/Vote/GetByDate/" + date + "/" + pageNum + "/" + pageSize, requestOptions);
    let data = await response.json();
    if (data.statusCode === 1) {
      return data.data;
    }
    else {
      return [];
    }
  }
  const handleClick = () => {
    myRefname.current.focus();
  }

  return (
    <div className="warp-content border-shadow">
      <div className="d-flex align-items-center justify-content-between app-bar">
        <div className="d-flex align-items-center justify-content-between app-bar">
          <Icon.Justify className="app-bar-icon" />
          <span className="date-text"> September 19</span>
          <Icon.CaretDownFill className="app-bar-icon-down" onClick={handleClick}>

            <input type="date" id="datetimepicker1" ref={myRefname}></input>
          </Icon.CaretDownFill>

        </div>
        <div><Icon.PersonCircle className="app-bar-icon-persom" /></div>
      </div>
      <div>
        {listVote.map(item => (
          <Card style={{ width: "90%", margin: "10px auto" }} key={item.id}>
            <Card.Header style={{ height: "55px", backgroundColor: "#8ec0e6" }}>
              <div className="d-flex align-items-center justify-content-between">
                <div><span className="item-vote-name">{item.name}</span></div>
                <div>
                  <span className="item-vote-count">{item.totalVote}</span>
                  {item.totalVote === 0 ? <Icon.Heart className="app-bar-icon-heart" /> : <Icon.HeartFill className="app-bar-icon-heart-fill" />}
                </div>
              </div>
            </Card.Header>
            <Card.Body style={{ backgroundColor: "#2c8fda", height: "200px" }}>
              <div className="d-flex align-items-center justify-content-between" style={{ height: "100%", textAlign: "center" }}>
                <div style={{ width: "100%" }} className="vote-content">{item.voteContent}</div>
              </div>
            </Card.Body>
          </Card>
        ))}


      </div>
    </div>
  );
}
