import{_ as y,r as u,o as N,a as _,b as p,d as t,t as v,w as m,v as f,p as I,h as w,e as x,i as C,j as B,F as b,f as S,g as E,k as U}from"./style.js";import{s as h}from"./store.js";const g=l=>(I("data-v-4e2f5374"),l=l(),w(),l),O={class:"profileInfoSection"},V={key:0,class:"infoDisplayContainer"},M={class:"rowData"},P=g(()=>t("label",{for:"email"},"Email",-1)),R={id:"email"},F={class:"rowData"},A=g(()=>t("label",{for:"name"},"Name",-1)),q={id:"name"},J={class:"rowData"},L=g(()=>t("label",{for:"surname"},"Surname",-1)),T={id:"surname"},j={class:"rowData"},z=g(()=>t("label",{for:"displayName"},"DisplayName",-1)),G={id:"displayName"},H={class:"rowData"},K={key:1,class:"infoEditContainer"},Q={class:"rowData"},W=g(()=>t("label",{for:"email"},"Email",-1)),X={class:"rowData"},Y=g(()=>t("label",{for:"name"},"Name",-1)),Z={class:"rowData"},ee=g(()=>t("label",{for:"surname"},"Surname",-1)),te={class:"rowData"},se=g(()=>t("label",{for:"displayName"},"DisplayName",-1)),oe={__name:"ProfileInfo",setup(l){const i=u({editing:!1}),e=u({userId:null,email:null,firstName:null,surname:null,displayName:null,dateOfBirth:null}),s=u({userId:null,email:null,firstName:null,surname:null,displayName:null,dateOfBirth:null});N(()=>{getUserByEmail(h.userEmail,n=>{e.userId=n.data.userId,e.email=n.data.email,e.firstName=n.data.firstName,e.surname=n.data.surname,e.displayName=n.data.displayName,e.dateOfBirth=n.data.dateOfBirth,s.userId=n.data.userId,s.email=n.data.email,s.firstName=n.data.firstName,s.surname=n.data.surname,s.displayName=n.data.displayName,s.dateOfBirth=n.data.dateOfBirth},n=>{console.log(n)})});const r=()=>{e.userId=s.userId,e.email=s.email,e.firstName=s.firstName,e.surname=s.surname,e.displayName=s.displayName,e.dateOfBirth=s.dateOfBirth,i.editing=!1},d=()=>{editUser(e.userId,JSON.stringify(e),h.token,n=>{s.userId=e.userId,s.email=e.email,s.firstName=e.firstName,s.surname=e.surname,s.displayName=e.displayName,s.dateOfBirth=e.dateOfBirth,i.editing=!1},n=>{console.log(n)})};return(n,o)=>(_(),p("section",O,[i.editing==!1?(_(),p("div",V,[t("div",M,[P,t("p",R,v(e.email),1)]),t("div",F,[A,t("p",q,v(e.firstName),1)]),t("div",J,[L,t("p",T,v(e.surname),1)]),t("div",j,[z,t("p",G,v(e.displayName),1)]),t("div",H,[t("button",{onClick:o[0]||(o[0]=a=>i.editing=!0)},"Edit")])])):(_(),p("div",K,[t("div",Q,[W,m(t("input",{type:"text",disabled:"","onUpdate:modelValue":o[1]||(o[1]=a=>e.email=a)},null,512),[[f,e.email]])]),t("div",X,[Y,m(t("input",{type:"text","onUpdate:modelValue":o[2]||(o[2]=a=>e.firstName=a)},null,512),[[f,e.firstName]])]),t("div",Z,[ee,m(t("input",{type:"text","onUpdate:modelValue":o[3]||(o[3]=a=>e.surname=a)},null,512),[[f,e.surname]])]),t("div",te,[se,m(t("input",{type:"text","onUpdate:modelValue":o[4]||(o[4]=a=>e.displayName=a)},null,512),[[f,e.displayName]])]),t("div",{class:"rowData"},[t("button",{onClick:d},"Update"),t("button",{onClick:r},"Cancel")])]))]))}},ae=y(oe,[["__scopeId","data-v-4e2f5374"]]);const $=l=>(I("data-v-0ad29f08"),l=l(),w(),l),ne={key:0,class:"overlay"},le=$(()=>t("h2",null,"New Blog",-1)),ie={class:"inputContainer"},de={class:"dataRow"},re=$(()=>t("label",{for:"name"},"Name",-1)),ce={class:"dataRow"},_e=$(()=>t("label",{for:"description"},"Description",-1)),ue={__name:"NewBlogModal",props:{content:null},setup(l,{expose:i}){const e=u({userid:null,name:null,description:null,imageId:null});N(()=>{});const s=u({show:!1}),r=()=>{s.show=!1},d=o=>{s.show=!0},n=()=>{e.name!=null||e.description!=null?getUserByEmail(h.userEmail,o=>{e.userid=o.data.userId,createBlog(e,h.token,a=>{a.status==204&&(alert("Success"),s.show=!1)},a=>{console.log(a)})},o=>{console.log(o)}):alert("Fill in all the Fields")};return i({open:d}),(o,a)=>s.show?(_(),p("div",ne,[le,t("div",ie,[t("div",de,[re,m(t("input",{type:"text",id:"name","onUpdate:modelValue":a[0]||(a[0]=c=>e.name=c)},null,512),[[f,e.name]])]),t("div",ce,[_e,m(t("textarea",{id:"description","onUpdate:modelValue":a[1]||(a[1]=c=>e.description=c)},null,512),[[f,e.description]])]),t("div",{class:"dataRow"},[t("button",{onClick:n},"Save"),t("button",{onClick:r},"Cancel")])])])):x("",!0)}},pe=y(ue,[["__scopeId","data-v-0ad29f08"]]);const k=l=>(I("data-v-88dcc7f2"),l=l(),w(),l),me={key:0,class:"overlay"},fe=k(()=>t("h2",null,"Edit Blog",-1)),ge={class:"inputContainer"},ve={class:"dataRow"},he=k(()=>t("label",{for:"name"},"Name",-1)),ye={class:"dataRow"},Be=k(()=>t("label",{for:"description"},"Description",-1)),Ne={__name:"EditBlogModal",setup(l,{expose:i}){const e=u({blogId:null,description:null,imageId:null,name:null,userId:null}),s=u({show:!1}),r=()=>{s.show=!1},d=o=>{e.blogId=o.blogId,e.description=o.description,e.image=o.image,e.name=o.name,e.userId=o.userId,console.log(o),s.show=!0},n=()=>{var o={blogId:e.blogId,description:e.description,imageId:e.imageId,name:e.name,userId:e.userId};console.log(o),editBlog(e.blogId,o,h.token,a=>{alert("Blog Updated"),s.show=!1},a=>{var c=`Error:
`;for(const D in a.response.data.errors)c+=`${a.response.data.errors[D].toString()}
`;alert(c),console.log(a)})};return i({open:d}),(o,a)=>s.show?(_(),p("div",me,[fe,t("div",ge,[t("div",ve,[he,m(t("input",{type:"text",id:"name","onUpdate:modelValue":a[0]||(a[0]=c=>e.name=c)},null,512),[[f,e.name]])]),t("div",ye,[Be,m(t("textarea",{id:"description","onUpdate:modelValue":a[1]||(a[1]=c=>e.description=c)},null,512),[[f,e.description]])]),t("div",{class:"dataRow"},[t("button",{onClick:n},"Save"),t("button",{onClick:r},"Cancel")])])])):x("",!0)}},be=y(Ne,[["__scopeId","data-v-88dcc7f2"]]);const Ie={class:"blog"},we={class:"cover"},$e={class:"content"},ke={class:"numberofPosts"},xe={__name:"Blog",props:{content:null},setup(l){const i=l,e=C(null),s=u({content:null});N(()=>{s.content=i.content});const r=()=>{deleteBlog(s.content.blogId,h.token,d=>{s.content.postCount>0?alert("Blog and Associated Posts and comments Deleted"):alert("Blog Deleted")},d=>{alert(d)})};return(d,n)=>(_(),p(b,null,[t("div",Ie,[t("div",we,[t("i",{class:"fa-regular fa-pen-to-square",onClick:n[0]||(n[0]=o=>e.value.open(s.content))}),t("i",{class:"fa-solid fa-trash-can",onClick:r})]),t("div",$e,[t("h2",null,v(s.content.name),1),t("p",null,v(s.content.description),1),t("p",ke,v(s.content.postCount)+" Posts",1)])]),B(be,{ref_key:"editBlog",ref:e},null,512)],64))}},Ce=y(xe,[["__scopeId","data-v-3b2b280a"]]);const De={class:"blogsSection"},Se={class:"newBlog"},Ee={class:"blogs"},Ue={__name:"BlogSection",setup(l){const i=C(null),e=u({blogs:[]});return N(()=>{getBlogs(h.userEmail,s=>{e.blogs=s.data},s=>{console.log(s)})}),(s,r)=>(_(),p(b,null,[t("section",De,[t("div",Se,[t("button",{onClick:r[0]||(r[0]=(...d)=>i.value.open&&i.value.open(...d))},"New Blog")]),t("div",Ee,[(_(!0),p(b,null,S(e.blogs,d=>(_(),E(Ce,{key:d.blogId,content:d},null,8,["content"]))),128))])]),B(pe,{ref_key:"blogModal",ref:i},null,512)],64))}},Oe=y(Ue,[["__scopeId","data-v-13c63f2c"]]),Ve={class:"profilePageContainer"},Me={__name:"ProfilePage",setup(l){return(i,e)=>(_(),p("div",Ve,[B(ae),B(Oe)]))}};U(Me).mount("#app");
