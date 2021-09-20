import React, {useState} from "react";
import { Card, Button, Form } from 'react-bootstrap';
import './css.css';
function renderList(){
  let lst = this.state.listVote;
  const users = []
  for (let index = 0; index < lst.length; index++) {
    users.push(<h2>num is {index}</h2>);
  }
  return users;
}
export default function ListVote(props) {
  let changeMode = props.action;
  const [listVote, setlistVote] = useState([]);

  React.useEffect(() => {
    setlistVote([1, 2, 3]);
  });
 

  return (
    <div className="warp-content">
      <h1>list vote</h1>
      {this.renderList}
    </div>
  );
}
