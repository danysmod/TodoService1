export default class TodoService{
    _apiBase = 'http://localhost:59100/api'

    getResourceWithToken = async (url, token) => {
        if(token){
            const res = await fetch(`${this._apiBase}/${url}`,{
                method: "GET",
                headers: {
                    Accept:"application/json",
                    'Content-Type': 'application/json',
                    'Authorization': `Bearer ${token}`
                },
            });
    
            if(!res.ok){
                throw new Error("Ooops, error")
            }
    
            return await res.json();
        }

        return new Error('Token error')
    }

    postDataWithoutToken = async (url, data) => {
        const res = await fetch(`${this._apiBase}/${url}`,{
            method: "POST",
            headers: {
                Accept: 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data),
        })

        if(!res.ok){
            throw new Error("Ooops, error")
        }

        return await res.json();
    }

    postDataWithToken = async (url,token,data) => {
        if(token){
            const res = await fetch(`${this._apiBase}/${url}`,{
                method: "POST",
                headers: {
                    Accept:"application/json",
                    'Content-Type': 'application/json',
                    'Authorization': `Bearer ${token}`
                },
                body: JSON.stringify(data),
            });
    
            if(!res.ok){
                throw new Error("Ooops, error")
            }
    
            return await res.json();
        }

        return new Error('Token error')
    }

    login = async (userData) => {
        return await this.postDataWithoutToken("Login",userData);
    }

    register = async (userData) => {
        return await this.postDataWithoutToken("Register",userData);
    }

    getAccountDetails = async (token) => {
        const res = await this.getResourceWithToken('GetAccountDetails', token)
        return res;
    }

    createTable = async (token, data) => {
        return await this.postDataWithToken('table/Create', token, data);
    }

    getTableDetails = async (token, id) => {
        const data ={ 
            TableId: id
        }

        return await this.postDataWithToken(`table/GetDetails`, token, data)
    }

    completeTask = async (token, data) => {
        return await this.postDataWithToken('task/Complete', token, data)
    }

    deleteTask = async (token, data) => {
        return await this.postDataWithToken('task/Delete', token, data)
    }

    addTask = async(token, data) => {
        return await this.postDataWithToken('task/AddTask', token, data)
    }

    deleteTable = async(token, data) => {
        return await this.postDataWithToken('table/Delete', token, data)
    }
} 