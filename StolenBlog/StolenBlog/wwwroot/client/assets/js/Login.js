import{_ as m,r as c,o as _,c as u,a as e,w as l,v as d,n as g,p as w,b as f,q as b,i as v}from"./style.js";import{s as n}from"./store.js";const r=a=>(w("data-v-f47f9e46"),a=a(),f(),a),h={class:"overlay"},M={class:"loginContainer"},R={class:"dataRow"},k=r(()=>e("label",{for:"inpUsername"},"Username",-1)),x={class:"dataRow"},y=r(()=>e("label",{for:"inpPassword"},"Password",-1)),I={class:"dataRow"},U=r(()=>e("label",{for:"inpRememberMe"},"Remember Me",-1)),L=r(()=>e("p",null,[b("Don't Have an Account? "),e("span",null,[e("a",{href:"/Auth/Register"},"Register Here")])],-1)),S={__name:"Login",setup(a){const t=c({username:null,password:null,rememberMe:!1}),p=()=>{let i={Email:t.username,Password:t.password,RememberMe:t.rememberMe};login(i,o=>{getUserName(o.data.token,s=>{console.log(s),n.loggedIn=!0,n.userEmail=s.data,n.token=o.data.token,sessionStorage.setItem("storeData",JSON.stringify(n)),window.location.href="https://localhost:7183/Home/Index"},s=>{console.error(s)})},o=>{alert(o.response.data.errors[0]),console.log(o.response)})};return(i,o)=>(_(),u("div",h,[e("div",M,[e("div",R,[k,l(e("input",{type:"email",id:"inpUsername","onUpdate:modelValue":o[0]||(o[0]=s=>t.username=s)},null,512),[[d,t.username]])]),e("div",x,[y,l(e("input",{type:"password",id:"inpPassword","onUpdate:modelValue":o[1]||(o[1]=s=>t.password=s)},null,512),[[d,t.password]])]),e("div",I,[U,l(e("input",{type:"checkbox",id:"inpRememberMe","onUpdate:modelValue":o[2]||(o[2]=s=>t.rememberMe=s)},null,512),[[g,t.rememberMe]])]),e("div",{class:"dataRow"},[e("button",{onClick:p},"Login"),L])])]))}},V=m(S,[["__scopeId","data-v-f47f9e46"]]);v(V).mount("#app");