import React from "react";

const HomePage = () => {
    return (
        <div className="jumbotron">
            <h2>JBet</h2>
            <p>
                A sample application built using domain-driven design and .NET Core.
            </p>
            <a
                href="https://github.com/profjordanov/sports-system"
                className="btn btn-primary btn-md"
            >
                Check out the source code
            </a>
        </div>
    );
};

export default HomePage;