// ============================= Auth Requests ============================= //
function login(loginObj, success, error) {

    axios
        .post("https://localhost:7215/api/Authentication/Login", JSON.stringify(loginObj), {
            'headers': {
                'Content-Type': "application/json"
            }
        })
        .then(res => success(res))
        .catch(err => error(err));
}

function register(registerObj, success, error) {
    axios
        .post("https://localhost:7215/api/Authentication/Register", JSON.stringify(registerObj), {
            'headers': {
                'Content-Type': "application/json"
            }
        })
        .then(res => success(res))
        .catch(err => error(err));
}

function getUserName(token, success, error) {
    axios
        .get(`https://localhost:7215/api/Authentication/ReadToken/${token}`)
        .then(res => success(res))
        .catch(err => error(err));
}

function logout(success, error) {

    axios
        .post("https://localhost:7215/api/Authentication/Logout")
        .then(res => success(res))
        .catch(err => error(err));
}

function userSignedIn(success, error) {

    axios
        .get("https://localhost:7215/api/Authentication/UserSignedIn")
        .then(res => success(res))
        .catch(err => error(err));
}


// ============================= BlogPost Requests ============================= //
function getPosts(success, error) {
    axios
        .get("https://localhost:7215/api/BlogPosts")
        .then(res => success(res))
        .catch(err => error(err));
}

function getPost(postId, success, error) {
    axios
        .get(`https://localhost:7215/api/BlogPosts/${postId}`)
        .then(res => success(res))
        .catch(err => error(err));
}

function createPost(postObject, token, success, error) {
    axios
        .post(`https://localhost:7215/api/BlogPosts/`, JSON.stringify(postObject), {
            'headers': {
                'Content-Type': "application/json",
                'Authorization': `Bearer ${token}`
            }
        })
        .then(res => success(res))
        .catch(err => error(err));
}

function editPost(postId, postObject, token, success, error) {
    axios
        .put(`https://localhost:7215/api/BlogPosts/${postId}`, JSON.stringify(postObject), {
            'headers': {
                'Content-Type': "application/json",
                'Authorization': `Bearer ${token}`
            }
        })
        .then(res => success(res))
        .catch(err => error(err));
}

function deletePost(postId, token, success, error) {
    axios
        .delete(`https://localhost:7215/api/BlogPosts/${postId}`, {
            'headers': {
                'Content-Type': "application/json",
                'Authorization': `Bearer ${token}`
            }
        })
        .then(res => success(res))
        .catch(err => error(err));
}

// ============================= Blog Requests ============================= //
function getBlogs(username,success, error) {
    axios
        .get(`https://localhost:7215/api/Blogs/${username}`)
        .then(res => success(res))
        .catch(err => error(err));
}

// Probably Not needed for scope of my application
//function getBlog(postId, success, error) {
//    axios
//        .get(`https://localhost:7215/api/Blogs/${postId}`)
//        .then(res => success(res))
//        .catch(err => error(err));
//}

function createBlog(blogObject, token, success, error) {
    axios
        .post(`https://localhost:7215/api/Blogs/`, JSON.stringify(blogObject), {
            'headers': {
                'Content-Type': "application/json",
                'Authorization': `Bearer ${token}`
            }
        })
        .then(res => success(res))
        .catch(err => error(err));
}

function editBlog(blogId, blogObject, token, success, error) {
    axios
        .put(`https://localhost:7215/api/Blogs/${blogId}`, JSON.stringify(blogObject), {
            'headers': {
                'Content-Type': "application/json",
                'Authorization': `Bearer ${token}`
            }
        })
        .then(res => success(res))
        .catch(err => error(err));
}

function deleteBlog(blogId, token, success, error) {
    axios
        .delete(`https://localhost:7215/api/Blogs/${blogId}`, {
            'headers': {
                'Content-Type': "application/json",
                'Authorization': `Bearer ${token}`
            }
        })
        .then(res => success(res))
        .catch(err => error(err));
}

// ============================= Comments Requests ============================= //
function getComments(postId, success, error) {
    axios
        .get(`https://localhost:7215/api/Comments/${postId}`)
        .then(res => success(res))
        .catch(err => error(err));
}

// Probably Not needed for scope of my application
//function getComment(postId, success, error) {
//    axios
//        .get(`https://localhost:7215/api/BlogPosts/${postId}`)
//        .then(res => success(res))
//        .catch(err => error(err));
//}

function createComment(commentObject, token, success, error) {
    axios
        .post(`https://localhost:7215/api/Comments/`, JSON.stringify(commentObject), {
            'headers': {
                'Content-Type': "application/json",
                'Authorization': `Bearer ${token}`
            }
        })
        .then(res => success(res))
        .catch(err => error(err));
}

function editComment(commentId, commentObject, token, success, error) {
    axios
        .put(`https://localhost:7215/api/Comments/${commentId}`, JSON.stringify(commentObject), {
            'headers': {
                'Content-Type': "application/json",
                'Authorization': `Bearer ${token}`
            }
        })
        .then(res => success(res))
        .catch(err => error(err));
}

function deleteComment(commentId, token, success, error) {
    axios
        .delete(`https://localhost:7215/api/Comments/${commentId}`, {
            'headers': {
                'Content-Type': "application/json",
                'Authorization': `Bearer ${token}`
            }
        })
        .then(res => success(res))
        .catch(err => error(err));
}

// ============================= Users Requests ============================= //

//function getImages(success, error) {
//    axios
//        .get("https://localhost:7215/api/Users/")
//        .then(res => success(res))
//        .catch(err => error(err));
//}

function getUser(userId, success, error) {
    axios
        .get(`https://localhost:7215/api/Users/${userId}`)
        .then(res => success(res))
        .catch(err => error(err));
}

function editUser(userId, userObject, token, success, error) {
    axios
        .put(`https://localhost:7215/api/Users/${userId}`, JSON.stringify(userObject), {
            'headers': {
                'Content-Type': "application/json",
                'Authorization': `Bearer ${token}`
            }
        })
        .then(res => success(res))
        .catch(err => error(err));
}

function deleteUser(userId, token, success, error) {
    axios
        .delete(`https://localhost:7215/api/Users/${userId}`, {
            'headers': {
                'Content-Type': "application/json",
                'Authorization': `Bearer ${token}`
            }
        })
        .then(res => success(res))
        .catch(err => error(err));
}