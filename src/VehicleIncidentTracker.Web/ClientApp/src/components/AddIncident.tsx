import React, { Component } from 'react';
import { useHistory } from 'react-router-dom';

export class AddIncident extends Component<{}, {
    note: string;
    incidentDate: string;
    vin: string;
}> {

    constructor(props: any) {
        super(props);
        this.state = {
            note: '',
            incidentDate: '',
            vin: ''
        };

        this.handleVinChange = this.handleVinChange.bind(this);
        this.handleNoteChange = this.handleNoteChange.bind(this);
        this.handleIncidentDateChange = this.handleIncidentDateChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
        this.routeChange = this.routeChange.bind(this);
    }

    routeChange = () => {
        let path = '/';
        let history = useHistory();
        history.push(path);
    }

    handleNoteChange(e: any) {
        this.setState({ note: e.target.value });
    }
    handleIncidentDateChange(e: any) {
        this.setState({ incidentDate: e.target.value });
    }
    handleVinChange(e: any) {
        this.setState({ vin: e.target.value });
    }
    handleSubmit(e: any) {
        e.preventDefault();
        const note = this.state.note.trim();
        const vin = this.state.vin.trim();
        const incidentDate = this.state.incidentDate.trim();
        if (!note || !note || !incidentDate) {
            return;
        }

        fetch('incident', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ vin: vin, note: note, incidentDate: this.state.incidentDate })
        }).then(response => {
            this.routeChange();
        }).catch(function (err) {
            console.log(err);
        });
    }

    render() {

        return (
            <form className="incidentForm" onSubmit={this.handleSubmit}>
                <div className="form-group row">
                    <input className="form-control" 
                                type="text"
                                placeholder="VIN"
                                value={this.state.vin}
                                onChange={this.handleVinChange}
                    />
                </div>
                <div className="form-group row">
                    <input className="form-control" 
                                type="text"
                                placeholder="Incident Date (YYYY-MM-DD)"
                                value={this.state.incidentDate}
                                onChange={this.handleIncidentDateChange}
                        />
                </div>
                <div className="form-group row">
                    <input className="form-control" 
                                type="textarea"
                                placeholder="Note"
                                value={this.state.note}
                                onChange={this.handleNoteChange}
                            />
                    </div>
                <div className="form-group row">
                    <input className="btn btn-primary"
                        type="submit" value="Add" />
                 </div>
            </form>
        );
    }
}
