import React, { Component } from 'react';
import { withRouter } from "react-router-dom";
 
export class Medicine extends Component {
    static displayName = Medicine.name;
 
    constructor(props) {
        super(props);
        this.state = { medicines: [], loading: true };
        this.edit = this.edit.bind(this);
    }
 
    edit(studentId) {
        this.props.history.push('/medicine/detail/' + studentId);
        
    }
 
    componentDidMount() {
        this.populateMedicineData();
    }
 
    async populateMedicineData() {
        const response = await fetch('https://localhost:5001/api/medicine'
        );
 
        const data = await response.json();
 
        this.setState({ medicines: data, loading: false });
    }
 
    render() {
        return (
            <div>
                {/* <h2 className="text-center">Medicines List</h2> */}
                <div className="row">
                    <table className="table table-striped table-bordered">
 
                        <thead>
                            <tr>
                                <th> Name</th>
                                <th> Brand</th>
                                <th> Price</th>
                                <th> Quantity</th>
                                <th> Expiry</th>
                            </tr>
                        </thead>
                        <tbody>
                            {
                                this.state.medicines.map(
                                    medicine =>
                                        <tr key={medicine.id} onClick={() => this.edit(medicine.id)}>
                                            <td> {medicine.name}</td>
                                            <td> {medicine.brand}</td>
                                            <td> {medicine.price} </td>
                                            <td> {medicine.quantity}</td>
                                            <td> {medicine.expiry}</td>
                                        </tr>
                                )
                            }
                        </tbody>
                    </table>
 
                </div>
 
            </div>
        )
    }
}   
export default withRouter(Medicine);
//export default Student

