import React, { useState, useEffect, forwardRef } from "react";
import { Card, Popover, OverlayTrigger, Button } from "react-bootstrap";
import "./css.css";
import * as Icon from 'react-bootstrap-icons';
import DatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker.css";

export default function ListVote(props) {
  let changeMode = props.action;
  const [listVote, setlistVote] = useState([]);
  const [pageNum, setPageNum] = useState(1);
  const [pageSize, setPageSize] = useState(2);
  const [startDate, setStartDate] = useState(new Date());
  const [email] = useState(JSON.parse(localStorage.getItem('sample-vote')).email);
  useEffect(() => {
    async function fetchData() {
      let startD = new Date(startDate).toISOString().slice(0, 10);

      let kq = await getData(startD, pageNum, pageSize);

      if (listVote.length > 0) {
        setlistVote(listVote.concat(kq));
      }
      else {
        setlistVote(kq);
      }
    }
    fetchData();
  }, [startDate, pageNum, pageSize]);

  function handleWheel(e) {
    setPageSize(2);
    setPageNum(pageNum + 1);
  }

  async function getData(date, pageNum, pageSize) {
    if (listVote.length > 0 && listVote[0].totalRow < ((pageNum - 1) * pageSize)) {
      return [];
    }
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


  const CustomDateInput = forwardRef(({ value, onClick }, ref) => (
    <div onClick={onClick}>
      <span className="date-text">  {value}</span>
      <Icon.CaretDownFill className="app-bar-icon-down" ref={ref} />
    </div>
  ));
  async function handleChangeDate(date) {
    setlistVote([]);
    setPageNum(1);
    setPageSize(2);
    setStartDate(date);
  }
  async function handleVote(id) {
    let idVote = id;

    const requestOptions = {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({
        "clientId": idVote,
        "email": email
      })
    };
    let response = await fetch("https://localhost:44311/api/Vote/Submmit", requestOptions);
    let data = await response.json();
    if (data.statusCode === 1) {
      let listNew = listVote;
      setlistVote([]);
      listNew.forEach(element => {
        if (element.id === idVote) {
          element.totalVote++;
        }
      });
      setlistVote(listNew);
      alert(data.msg);
    }
    else {
      alert(data.msg);
    }
  }
  const popover = (
    <Popover id="popover-basic" style={{width:"fit-content"}}>
      <Popover.Content>
        <p>Hello: {email.substr(0, email.indexOf("@") )}</p>
        <Button variant="link" onClick={() => {localStorage.removeItem("sample-vote"); changeMode("login");}} >Logout</Button>
      </Popover.Content>
    </Popover>
  );
  return (
    <div className="warp-content border-shadow" onWheel={handleWheel}>
      <div className="d-flex align-items-center justify-content-between app-bar">
        <div className="d-flex align-items-center justify-content-between app-bar">
          <Icon.Justify className="app-bar-icon" />
          <DatePicker
            selected={startDate}
            onChange={handleChangeDate}
            customInput={<CustomDateInput />}
            dateFormat="MMMM d"
          />

        </div>
        <div >
          <OverlayTrigger trigger="click" overlay={popover} placement="bottom">
            <Icon.PersonCircle className="app-bar-icon-persom" />
          </OverlayTrigger>
        </div>
      </div>
      <div>
        {listVote.map(item => (
          <Card style={{ width: "90%", margin: "10px auto" }} key={item.id}>
            <Card.Header style={{ height: "55px", backgroundColor: "#8ec0e6" }}>
              <div className="d-flex align-items-center justify-content-between">
                <div><span className="item-vote-name">{item.name}</span></div>
                <div>
                  <span className="item-vote-count">{item.totalVote}</span>
                  <span onClick={() => { handleVote(item.id) }} className="app-bar-icon-heart" >
                    {item.totalVote === 0 ? <Icon.Heart className="app-bar-icon-heart-no-fill" /> : <Icon.HeartFill className="app-bar-icon-heart-fill" />}
                  </span>

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
