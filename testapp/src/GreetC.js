import React from 'react';

class GreetC extends React.Component {
    render() {
        return <p>This is from class - Hi {this.props.name}</p>
    }
}
export default GreetC;