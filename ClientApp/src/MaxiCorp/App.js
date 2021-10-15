import React from "react";
import {
  BrowserRouter as Router,
  Switch,
  Route
} from "react-router-dom";
import Add from "./Add";
import Edit from "./Edit";
import Nav from 'react-bootstrap/Nav';
import List from "./List";

export default function App() {
  return (
    <Router>
        <div style={{width:"500px", margin: "0 auto",}}>
            <Nav activeKey="/">
                <Nav.Item>
                    <Nav.Link href="/">Danh sách</Nav.Link>
                </Nav.Item>
                <Nav.Item>
                    <Nav.Link href="/Add">Thêm mới</Nav.Link>
                </Nav.Item>
            </Nav>
            <Switch>
                <Route component={List} path="/" exact={true} />
                <Route component={Add} path="/Add" />
                <Route component={Edit} path="/Edit/:id" />
            </Switch>
      </div>
    </Router>
  );
}
