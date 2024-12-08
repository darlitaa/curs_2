let team = {
    players: [
        { name: "Михаил", role: "Защитник" },
        { name: "Игорь", role: "Вратарь" },
        { name: "Максим", role: "Нападающий" }
    ],

    getPlayers() {
        this.players.forEach(player => {
            console.log(`имя: ${player.name}, позиция: ${player.role}`)
        }
        );
    }
}

team.getPlayers();
