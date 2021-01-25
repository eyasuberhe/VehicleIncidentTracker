import React, { Component } from 'react';
import DatePicker from "react-datepicker";
import * as _ from 'lodash';

export interface IIncident {
    id: number;
    note: string;
    incidentDate: Date;
    vin: string;
    make: string;
    model: string;
    year: string;
    vehicleId: string;
}

export interface IFilters {
    vin?: string;
    startDate?: Date;
    endDate?: Date;
}

export class FetchData extends Component<{}, {
    incidents: IIncident[], filteredData: IIncident[], filters: IFilters, loading: boolean
}> {
    static displayName = FetchData.name;

    constructor(props: any) {
        super(props);
        this.state = {
            incidents: [],
            filteredData: [],
            filters: {
                vin: '',
                startDate: undefined,
                endDate: undefined
            },
            loading: true
        };

        this.applyFilter = this.applyFilter.bind(this);
        this.handleVinChange = this.handleVinChange.bind(this);
    }

    componentDidMount() {
        this.populateWeatherData();
    }

    handleVinChange(e: any) {
        let filters = this.state.filters;
        filters.vin = e.target.value;
        this.setState({ filters: filters });
    }

    applyFilter() {
        const filters = this.state.filters;
        let filteredData = this.state.incidents;
        if (filters.vin != null && filters.vin.trim() != '') {
            filteredData = _.filter(filteredData, (i) => {
                return _.includes(i.vin.toLocaleLowerCase(), filters.vin.toLocaleLowerCase());
            });
        }

        this.setState({ filteredData: filteredData });
    }

    static renderIncidentsTable(incidents: IIncident[]) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>VIN</th>
                        <th>Make</th>
                        <th>Model</th>
                        <th>Year</th>
                        <th>Incident Date</th>
                        <th>Note</th>
                    </tr>
                </thead>
                <tbody>
                    {incidents.map(incident =>
                        <tr key={incident.id}>
                            <td>{incident.vin}</td>
                            <td>{incident.make}</td>
                            <td>{incident.model}</td>
                            <td>{incident.year}</td>
                            <td>{incident.incidentDate}</td>
                            <td>{incident.note}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        const {
            filters,
            incidents,
            filteredData
        } = this.state;
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : FetchData.renderIncidentsTable(filteredData);

        return (
            <>
                <div className="form-group row">
                    <div className="col-md-6 col-sm-12">
                        <span style={{ paddingRight: 10 }}>
                            <input
                                type="text"
                                placeholder="VIN"
                                value={filters.vin}
                                onChange={this.handleVinChange}
                            />
                        </span>
                        <span>
                            <input type="button" value="Filter" onClick={this.applyFilter} />
                        </span>
                    </div>
                </div>
                <div>
                    <h1 id="tabelLabel" >Vehicle Incidents</h1>
                    {contents}
                </div>
            </>
        );
    }

    async populateWeatherData() {
        const response = await fetch('incident');
        const data = await response.json();
        this.setState({ incidents: data, filteredData: data, loading: false });
    }
}
