const team={
    _players: [
        {
            firstName:"Jhon", lastName: "Smith",age:25
        },
        {
            firstName:"James", lastName: "Williams", age: 20
        },
        {
            firstName:"Chris", lastName:"Wilson", age:19
        }
    ],
    _games: [
        {
            opponents: "Broncos", teamPoints: 42, oppenentPoints: 27
        },
        {
            opponents: "Wolves", teamPoints: 23, oppenentPoints: 20
        },
        {
            opponents: "Lions", teamPoints: 15, oppenentPoints: 18
        }
    ],
    get players() {
        return this._players;
    },
    get games() {
        return this._games;
    },
    addPlayer(firstName, lastName, age) {
        let player={
            firstName: firstName,
            lastName: lastName,
            age: age
        };
        this.players.push(player);
    },
    addGame(oppName,points, oppPoints){
        const game={
            opponent: oppPoints,
            points: points,
            oppenentPoints: oppPoints
        }
        this.games.push(game);
    }
};

team.addPlayer("Steph", "Curry", 28);
team.addPlayer("Lisa", "Leslie", 44);
team.addPlayer("Bugs", "Bunny", 76);

console.log(team.players);

team.addGame("Sea Lions", 100, 50);
team.addGame("Wolves", 56,90);
team.addGame("Tiger", 30,74);

console.log(team.games);