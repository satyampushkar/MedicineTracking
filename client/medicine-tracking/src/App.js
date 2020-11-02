import logo from './logo.svg';
import './App.css';
import {BrowserRouter as Router, Route, Switch} from 'react-router-dom'
import Header from './component/Header';
import Footer from './component/Footer';
import Medicine from './component/Medicine';

function App() {
  return (
    <div className="App">
      <Router>
              <Header />
                <div className="container">
                    <Switch> 
                          <Route path = "/" exact component = {Medicine}></Route>
                          <Route path = "/medicine" component = {Medicine}></Route>
                    </Switch>
                </div>
              <Footer />
        </Router>
    </div>
  );
}

export default App;
