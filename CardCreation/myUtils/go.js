
term = new ActiveXObject("SmartDeck.Terminal"
term.connectpcsc("Gemplus USB Smart Card Reader 0");
term.cleanbycertgen();
term.loadbycertgen("eloyalty", "eloyalty.hzx");
term.selectbyname("eloyalty");term.logcommands("ex1.log");
term.setcommand("70 30 00 00 02");
term.exchange();
term.disconnect();