import{_,r as u,a as g,b as v,d as e,w as d,v as p,m as w,p as b,h as f,n as h,k}from"./style.js";import{s as i}from"./store.js";const l=a=>(b("data-v-e1f4e1e2"),a=a(),f(),a),y={class:"overlay"},M={class:"loginContainer"},R={class:"dataRow"},x=l(()=>e("label",{for:"inpUsername"},"Username",-1)),S={class:"dataRow"},I=l(()=>e("label",{for:"inpPassword"},"Password",-1)),U={class:"dataRow"},L=l(()=>e("label",{for:"inpRememberMe"},"Remember Me",-1)),E=l(()=>e("p",null,[h("Don't Have an Account? "),e("span",null,[e("a",{href:"/Auth/Register"},"Register Here")])],-1)),P={__name:"Login",setup(a){const t=u({username:null,password:null,rememberMe:!1}),m=()=>{let r={Email:t.username,Password:t.password,RememberMe:t.rememberMe};if(r.Email==null||r.Password==null){alert("Fields cannot be Empty ");return}login(r,s=>{getUserName(s.data.token,o=>{i.loggedIn=!0,i.userEmail=o.data,i.token=s.data.token,sessionStorage.setItem("storeData",JSON.stringify(i)),alert("Login Success."),window.location.href="https://localhost:7183/Home/Index"},o=>{var n="";for(const c in rej.response.data.errors)n+=`${rej.response.data.errors[c].toString()}
`;alert(n)})},s=>{var o="";for(const n in s.response.data.errors)o+=`${s.response.data.errors[n].toString()}
`;alert(o)})};return(r,s)=>(g(),v("div",y,[e("div",M,[e("div",R,[x,d(e("input",{type:"email",id:"inpUsername","onUpdate:modelValue":s[0]||(s[0]=o=>t.username=o)},null,512),[[p,t.username]])]),e("div",S,[I,d(e("input",{type:"password",id:"inpPassword","onUpdate:modelValue":s[1]||(s[1]=o=>t.password=o)},null,512),[[p,t.password]])]),e("div",U,[L,d(e("input",{type:"checkbox",id:"inpRememberMe","onUpdate:modelValue":s[2]||(s[2]=o=>t.rememberMe=o)},null,512),[[w,t.rememberMe]])]),e("div",{class:"dataRow"},[e("button",{onClick:m},"Login"),E])])]))}},V=_(P,[["__scopeId","data-v-e1f4e1e2"]]);k(V).mount("#app");
