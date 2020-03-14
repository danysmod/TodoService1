export default class TodoService{
    data = {
        token: "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6ImRhbnlzbW9kNkBnbWFpbC5jb20iLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9lbWFpbGFkZHJlc3MiOiJkYW55c21vZDZAZ21haWwuY29tIiwiQWNjb3VudElkIjoiZDBlNzA2NmQtN2Y2YS00Zjg2LTg1MTMtYTBhYjk5ZjQ3MmIxIiwiZXhwIjoxNTgzNzk4Mjk5LCJpc3MiOiJDb3JlSWRlbnRpdHkiLCJhdWQiOiJDb3JlSWRlbnRpdHlVc2VyIn0.IqosCjMTvv_Zdyce7RkQyAsANHgNohK4mfFGTGIPRfk",
        accountDetails: {
            accountId: "d0e7066d-7f6a-4f86-8513-a0ab99f472b1",
            name: "danysmod6@gmail.com",
            tables: [
                {
                    tableId: "27de37d3-a306-41d7-ad9d-22877b047559",
                    tableName: "Table namba one",
                    state: 0,
                    tasks: []
                },
                {
                    tableId: "807638de-584a-4ac7-9a2f-24cc3ae1f754",
                    tableName: "Table namba two",
                    state: 0,
                    tasks: []
                },
                {
                    tableId: "3138d679-42e2-4e13-9938-42b530d3799f",
                    tableName: "Table namba two",
                    state: 0,
                    tasks: [
                        {
                            taskId: "d9f04204-4f40-4cc3-8b7e-4a90e5e0f991",
                            title: "First task in db",
                            state: 0
                        },
                        {
                            taskId: "6a04fdde-4e6b-476e-a727-a95672b5d383",
                            title: "First task in db",
                            state: 0
                        },
                        {
                            taskId: "47941f39-9d9a-40eb-8ded-4f4896ce1b48",
                            title: "First task in db",
                            state: 0
                        },
                        {
                            taskId: "43a51ee1-47f4-4dec-a8fd-90574238cf51",
                            title: "Last table in db",
                            state: 0
                        }
                    ]
                }
            ]
        }
    }

    getData(){
        return new Promise((resolve) => {
            setTimeout( ()=>{
                resolve(this.data)
            })
        }, 500) 
    }
}