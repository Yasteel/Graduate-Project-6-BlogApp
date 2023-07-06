// API Calls For Blogs
const getBlogs: Function = (callback: Function) => {
    axios
        .get(`https://localhost:7226/api/`)
        .then(res => callback(res))
        .catch(err => console.error(err))
}

const getBlog: Function = (blogId:number, callback: Function) => {
    axios
        .get(`https://localhost:7226/api/Blogs/${blogId}`)
        .then(res => callback(res))
        .catch(err => console.error(err))
}

const createBlog: Function = (data:JSON, callback:Function) => {
    let blogData = JSON.stringify(data)

    axios
        .post(`https://localhost:7226/api/Blogs/${blogId}`, blogData, {
            headers: {
                'Content-Type': 'application/json'
            }
        })
        .then(res => callback(res))
        .catch(err => console.error(err))
}

const updateBlog: Function = (editInfo:Object) => {

}

const deleteBlog: Function = () => {

}


