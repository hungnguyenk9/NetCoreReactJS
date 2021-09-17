import React, { Component } from 'react';
import Checkbox from 'material-ui/Checkbox';

export class Login extends Component {
  static displayName = "222";

  constructor(props) {
    super(props);
    this.state = { currentCount: 0 };
    this.incrementCounter = this.incrementCounter.bind(this);
  }

  incrementCounter() {
    this.setState({
      currentCount: this.state.currentCount + 1
    });
  }

  render() {
    return (
      <div>
        <h1>Counter</h1>
        <Checkbox/>
      </div>
    );
  }
}
