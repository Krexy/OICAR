var MyComponent = React.createClass({
  render :function(){
    return(
      <h2>Hello World!!</h2>
    );
  }
});

ReactDOM.render(
    <MyComponent/>, document.getElementById('root')
);
  