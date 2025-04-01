import './polyfills.server.mjs';
import{a as O,b as me,c as ge,d as _e,e as ve,h as ye,n as Ce}from"./chunk-3VFJ7ON5.mjs";import{$ as L,Aa as h,Ba as S,Fa as ce,I as p,J as m,Ka as de,L as H,N as ie,O as M,R as F,Sa as I,T as ne,Ta as f,Ua as he,Ya as fe,aa as re,bb as pe,f as J,ga as se,i as Q,ma as C,n as ee,na as oe,oa as ae,pa as le,s as te,sa as ue,ta as E,wa as d,xa as u,ya as w,za as $}from"./chunk-HE2RMMJH.mjs";import{a as o,b as a}from"./chunk-5XUXGTUW.mjs";function c(n){return n==null||(typeof n=="string"||Array.isArray(n))&&n.length===0}function Fe(n){return n!=null&&typeof n.length=="number"}var Le=/^(?=.{1,254}$)(?=.{1,64}@)[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+)*@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$/,x=class{static min(e){return $e(e)}static max(e){return We(e)}static required(e){return qe(e)}static requiredTrue(e){return ze(e)}static email(e){return Ze(e)}static minLength(e){return Ye(e)}static maxLength(e){return Xe(e)}static pattern(e){return Ke(e)}static nullValidator(e){return Ee(e)}static compose(e){return xe(e)}static composeAsync(e){return Pe(e)}};function $e(n){return e=>{if(c(e.value)||c(n))return null;let t=parseFloat(e.value);return!isNaN(t)&&t<n?{min:{min:n,actual:e.value}}:null}}function We(n){return e=>{if(c(e.value)||c(n))return null;let t=parseFloat(e.value);return!isNaN(t)&&t>n?{max:{max:n,actual:e.value}}:null}}function qe(n){return c(n.value)?{required:!0}:null}function ze(n){return n.value===!0?null:{required:!0}}function Ze(n){return c(n.value)||Le.test(n.value)?null:{email:!0}}function Ye(n){return e=>c(e.value)||!Fe(e.value)?null:e.value.length<n?{minlength:{requiredLength:n,actualLength:e.value.length}}:null}function Xe(n){return e=>Fe(e.value)&&e.value.length>n?{maxlength:{requiredLength:n,actualLength:e.value.length}}:null}function Ke(n){if(!n)return Ee;let e,t;return typeof n=="string"?(t="",n.charAt(0)!=="^"&&(t+="^"),t+=n,n.charAt(n.length-1)!=="$"&&(t+="$"),e=new RegExp(t)):(t=n.toString(),e=n),i=>{if(c(i.value))return null;let r=i.value;return e.test(r)?null:{pattern:{requiredPattern:t,actualValue:r}}}}function Ee(n){return null}function we(n){return n!=null}function Se(n){return ce(n)?Q(n):n}function Ie(n){let e={};return n.forEach(t=>{e=t!=null?o(o({},e),t):e}),Object.keys(e).length===0?null:e}function Oe(n,e){return e.map(t=>t(n))}function Je(n){return!n.validate}function Ne(n){return n.map(e=>Je(e)?e:t=>e.validate(t))}function xe(n){if(!n)return null;let e=n.filter(we);return e.length==0?null:function(t){return Ie(Oe(t,e))}}function Qe(n){return n!=null?xe(Ne(n)):null}function Pe(n){if(!n)return null;let e=n.filter(we);return e.length==0?null:function(t){let i=Oe(t,e).map(Se);return te(i).pipe(ee(Ie))}}function et(n){return n!=null?Pe(Ne(n)):null}function q(n){return n?Array.isArray(n)?n:[n]:[]}function P(n,e){return Array.isArray(n)?n.includes(e):n===e}function Ve(n,e){let t=q(e);return q(n).forEach(r=>{P(t,r)||t.push(r)}),t}function De(n,e){return q(e).filter(t=>!P(n,t))}var tt={"[class.ng-untouched]":"isUntouched","[class.ng-touched]":"isTouched","[class.ng-pristine]":"isPristine","[class.ng-dirty]":"isDirty","[class.ng-valid]":"isValid","[class.ng-invalid]":"isInvalid","[class.ng-pending]":"isPending"},Lt=a(o({},tt),{"[class.ng-submitted]":"isSubmitted"});var V="VALID",N="INVALID",g="PENDING",D="DISABLED",v=class{},k=class extends v{constructor(e,t){super(),this.value=e,this.source=t}},b=class extends v{constructor(e,t){super(),this.pristine=e,this.source=t}},A=class extends v{constructor(e,t){super(),this.touched=e,this.source=t}},_=class extends v{constructor(e,t){super(),this.status=e,this.source=t}};function Y(n){return(G(n)?n.validators:n)||null}function it(n){return Array.isArray(n)?Qe(n):n||null}function X(n,e){return(G(e)?e.asyncValidators:n)||null}function nt(n){return Array.isArray(n)?et(n):n||null}function G(n){return n!=null&&!Array.isArray(n)&&typeof n=="object"}function ke(n,e,t){let i=n.controls;if(!(e?Object.keys(i):i).length)throw new p(1e3,"");if(!i[t])throw new p(1001,"")}function Re(n,e,t){n._forEachChild((i,r)=>{if(t[r]===void 0)throw new p(1002,"")})}var y=class{constructor(e,t){this._pendingDirty=!1,this._hasOwnPendingAsyncValidator=null,this._pendingTouched=!1,this._onCollectionChange=()=>{},this._parent=null,this._status=I(()=>this.statusReactive()),this.statusReactive=E(void 0),this._pristine=I(()=>this.pristineReactive()),this.pristineReactive=E(!0),this._touched=I(()=>this.touchedReactive()),this.touchedReactive=E(!1),this._events=new J,this.events=this._events.asObservable(),this._onDisabledChange=[],this._assignValidators(e),this._assignAsyncValidators(t)}get validator(){return this._composedValidatorFn}set validator(e){this._rawValidators=this._composedValidatorFn=e}get asyncValidator(){return this._composedAsyncValidatorFn}set asyncValidator(e){this._rawAsyncValidators=this._composedAsyncValidatorFn=e}get parent(){return this._parent}get status(){return f(this.statusReactive)}set status(e){f(()=>this.statusReactive.set(e))}get valid(){return this.status===V}get invalid(){return this.status===N}get pending(){return this.status==g}get disabled(){return this.status===D}get enabled(){return this.status!==D}get pristine(){return f(this.pristineReactive)}set pristine(e){f(()=>this.pristineReactive.set(e))}get dirty(){return!this.pristine}get touched(){return f(this.touchedReactive)}set touched(e){f(()=>this.touchedReactive.set(e))}get untouched(){return!this.touched}get updateOn(){return this._updateOn?this._updateOn:this.parent?this.parent.updateOn:"change"}setValidators(e){this._assignValidators(e)}setAsyncValidators(e){this._assignAsyncValidators(e)}addValidators(e){this.setValidators(Ve(e,this._rawValidators))}addAsyncValidators(e){this.setAsyncValidators(Ve(e,this._rawAsyncValidators))}removeValidators(e){this.setValidators(De(e,this._rawValidators))}removeAsyncValidators(e){this.setAsyncValidators(De(e,this._rawAsyncValidators))}hasValidator(e){return P(this._rawValidators,e)}hasAsyncValidator(e){return P(this._rawAsyncValidators,e)}clearValidators(){this.validator=null}clearAsyncValidators(){this.asyncValidator=null}markAsTouched(e={}){let t=this.touched===!1;this.touched=!0;let i=e.sourceControl??this;this._parent&&!e.onlySelf&&this._parent.markAsTouched(a(o({},e),{sourceControl:i})),t&&e.emitEvent!==!1&&this._events.next(new A(!0,i))}markAllAsTouched(e={}){this.markAsTouched({onlySelf:!0,emitEvent:e.emitEvent,sourceControl:this}),this._forEachChild(t=>t.markAllAsTouched(e))}markAsUntouched(e={}){let t=this.touched===!0;this.touched=!1,this._pendingTouched=!1;let i=e.sourceControl??this;this._forEachChild(r=>{r.markAsUntouched({onlySelf:!0,emitEvent:e.emitEvent,sourceControl:i})}),this._parent&&!e.onlySelf&&this._parent._updateTouched(e,i),t&&e.emitEvent!==!1&&this._events.next(new A(!1,i))}markAsDirty(e={}){let t=this.pristine===!0;this.pristine=!1;let i=e.sourceControl??this;this._parent&&!e.onlySelf&&this._parent.markAsDirty(a(o({},e),{sourceControl:i})),t&&e.emitEvent!==!1&&this._events.next(new b(!1,i))}markAsPristine(e={}){let t=this.pristine===!1;this.pristine=!0,this._pendingDirty=!1;let i=e.sourceControl??this;this._forEachChild(r=>{r.markAsPristine({onlySelf:!0,emitEvent:e.emitEvent})}),this._parent&&!e.onlySelf&&this._parent._updatePristine(e,i),t&&e.emitEvent!==!1&&this._events.next(new b(!0,i))}markAsPending(e={}){this.status=g;let t=e.sourceControl??this;e.emitEvent!==!1&&(this._events.next(new _(this.status,t)),this.statusChanges.emit(this.status)),this._parent&&!e.onlySelf&&this._parent.markAsPending(a(o({},e),{sourceControl:t}))}disable(e={}){let t=this._parentMarkedDirty(e.onlySelf);this.status=D,this.errors=null,this._forEachChild(r=>{r.disable(a(o({},e),{onlySelf:!0}))}),this._updateValue();let i=e.sourceControl??this;e.emitEvent!==!1&&(this._events.next(new k(this.value,i)),this._events.next(new _(this.status,i)),this.valueChanges.emit(this.value),this.statusChanges.emit(this.status)),this._updateAncestors(a(o({},e),{skipPristineCheck:t}),this),this._onDisabledChange.forEach(r=>r(!0))}enable(e={}){let t=this._parentMarkedDirty(e.onlySelf);this.status=V,this._forEachChild(i=>{i.enable(a(o({},e),{onlySelf:!0}))}),this.updateValueAndValidity({onlySelf:!0,emitEvent:e.emitEvent}),this._updateAncestors(a(o({},e),{skipPristineCheck:t}),this),this._onDisabledChange.forEach(i=>i(!1))}_updateAncestors(e,t){this._parent&&!e.onlySelf&&(this._parent.updateValueAndValidity(e),e.skipPristineCheck||this._parent._updatePristine({},t),this._parent._updateTouched({},t))}setParent(e){this._parent=e}getRawValue(){return this.value}updateValueAndValidity(e={}){if(this._setInitialStatus(),this._updateValue(),this.enabled){let i=this._cancelExistingSubscription();this.errors=this._runValidator(),this.status=this._calculateStatus(),(this.status===V||this.status===g)&&this._runAsyncValidator(i,e.emitEvent)}let t=e.sourceControl??this;e.emitEvent!==!1&&(this._events.next(new k(this.value,t)),this._events.next(new _(this.status,t)),this.valueChanges.emit(this.value),this.statusChanges.emit(this.status)),this._parent&&!e.onlySelf&&this._parent.updateValueAndValidity(a(o({},e),{sourceControl:t}))}_updateTreeValidity(e={emitEvent:!0}){this._forEachChild(t=>t._updateTreeValidity(e)),this.updateValueAndValidity({onlySelf:!0,emitEvent:e.emitEvent})}_setInitialStatus(){this.status=this._allControlsDisabled()?D:V}_runValidator(){return this.validator?this.validator(this):null}_runAsyncValidator(e,t){if(this.asyncValidator){this.status=g,this._hasOwnPendingAsyncValidator={emitEvent:t!==!1};let i=Se(this.asyncValidator(this));this._asyncValidationSubscription=i.subscribe(r=>{this._hasOwnPendingAsyncValidator=null,this.setErrors(r,{emitEvent:t,shouldHaveEmitted:e})})}}_cancelExistingSubscription(){if(this._asyncValidationSubscription){this._asyncValidationSubscription.unsubscribe();let e=this._hasOwnPendingAsyncValidator?.emitEvent??!1;return this._hasOwnPendingAsyncValidator=null,e}return!1}setErrors(e,t={}){this.errors=e,this._updateControlsErrors(t.emitEvent!==!1,this,t.shouldHaveEmitted)}get(e){let t=e;return t==null||(Array.isArray(t)||(t=t.split(".")),t.length===0)?null:t.reduce((i,r)=>i&&i._find(r),this)}getError(e,t){let i=t?this.get(t):this;return i&&i.errors?i.errors[e]:null}hasError(e,t){return!!this.getError(e,t)}get root(){let e=this;for(;e._parent;)e=e._parent;return e}_updateControlsErrors(e,t,i){this.status=this._calculateStatus(),e&&this.statusChanges.emit(this.status),(e||i)&&this._events.next(new _(this.status,t)),this._parent&&this._parent._updateControlsErrors(e,t,i)}_initObservables(){this.valueChanges=new L,this.statusChanges=new L}_calculateStatus(){return this._allControlsDisabled()?D:this.errors?N:this._hasOwnPendingAsyncValidator||this._anyControlsHaveStatus(g)?g:this._anyControlsHaveStatus(N)?N:V}_anyControlsHaveStatus(e){return this._anyControls(t=>t.status===e)}_anyControlsDirty(){return this._anyControls(e=>e.dirty)}_anyControlsTouched(){return this._anyControls(e=>e.touched)}_updatePristine(e,t){let i=!this._anyControlsDirty(),r=this.pristine!==i;this.pristine=i,this._parent&&!e.onlySelf&&this._parent._updatePristine(e,t),r&&this._events.next(new b(this.pristine,t))}_updateTouched(e={},t){this.touched=this._anyControlsTouched(),this._events.next(new A(this.touched,t)),this._parent&&!e.onlySelf&&this._parent._updateTouched(e,t)}_registerOnCollectionChange(e){this._onCollectionChange=e}_setUpdateStrategy(e){G(e)&&e.updateOn!=null&&(this._updateOn=e.updateOn)}_parentMarkedDirty(e){let t=this._parent&&this._parent.dirty;return!e&&!!t&&!this._parent._anyControlsDirty()}_find(e){return null}_assignValidators(e){this._rawValidators=Array.isArray(e)?e.slice():e,this._composedValidatorFn=it(this._rawValidators)}_assignAsyncValidators(e){this._rawAsyncValidators=Array.isArray(e)?e.slice():e,this._composedAsyncValidatorFn=nt(this._rawAsyncValidators)}},R=class extends y{constructor(e,t,i){super(Y(t),X(i,t)),this.controls=e,this._initObservables(),this._setUpdateStrategy(t),this._setUpControls(),this.updateValueAndValidity({onlySelf:!0,emitEvent:!!this.asyncValidator})}registerControl(e,t){return this.controls[e]?this.controls[e]:(this.controls[e]=t,t.setParent(this),t._registerOnCollectionChange(this._onCollectionChange),t)}addControl(e,t,i={}){this.registerControl(e,t),this.updateValueAndValidity({emitEvent:i.emitEvent}),this._onCollectionChange()}removeControl(e,t={}){this.controls[e]&&this.controls[e]._registerOnCollectionChange(()=>{}),delete this.controls[e],this.updateValueAndValidity({emitEvent:t.emitEvent}),this._onCollectionChange()}setControl(e,t,i={}){this.controls[e]&&this.controls[e]._registerOnCollectionChange(()=>{}),delete this.controls[e],t&&this.registerControl(e,t),this.updateValueAndValidity({emitEvent:i.emitEvent}),this._onCollectionChange()}contains(e){return this.controls.hasOwnProperty(e)&&this.controls[e].enabled}setValue(e,t={}){Re(this,!0,e),Object.keys(e).forEach(i=>{ke(this,!0,i),this.controls[i].setValue(e[i],{onlySelf:!0,emitEvent:t.emitEvent})}),this.updateValueAndValidity(t)}patchValue(e,t={}){e!=null&&(Object.keys(e).forEach(i=>{let r=this.controls[i];r&&r.patchValue(e[i],{onlySelf:!0,emitEvent:t.emitEvent})}),this.updateValueAndValidity(t))}reset(e={},t={}){this._forEachChild((i,r)=>{i.reset(e?e[r]:null,{onlySelf:!0,emitEvent:t.emitEvent})}),this._updatePristine(t,this),this._updateTouched(t,this),this.updateValueAndValidity(t)}getRawValue(){return this._reduceChildren({},(e,t,i)=>(e[i]=t.getRawValue(),e))}_syncPendingControls(){let e=this._reduceChildren(!1,(t,i)=>i._syncPendingControls()?!0:t);return e&&this.updateValueAndValidity({onlySelf:!0}),e}_forEachChild(e){Object.keys(this.controls).forEach(t=>{let i=this.controls[t];i&&e(i,t)})}_setUpControls(){this._forEachChild(e=>{e.setParent(this),e._registerOnCollectionChange(this._onCollectionChange)})}_updateValue(){this.value=this._reduceValue()}_anyControls(e){for(let[t,i]of Object.entries(this.controls))if(this.contains(t)&&e(i))return!0;return!1}_reduceValue(){let e={};return this._reduceChildren(e,(t,i,r)=>((i.enabled||this.disabled)&&(t[r]=i.value),t))}_reduceChildren(e,t){let i=e;return this._forEachChild((r,s)=>{i=t(i,r,s)}),i}_allControlsDisabled(){for(let e of Object.keys(this.controls))if(this.controls[e].enabled)return!1;return Object.keys(this.controls).length>0||this.disabled}_find(e){return this.controls.hasOwnProperty(e)?this.controls[e]:null}};var z=class extends R{};function be(n,e){let t=n.indexOf(e);t>-1&&n.splice(t,1)}function Ae(n){return typeof n=="object"&&n!==null&&Object.keys(n).length===2&&"value"in n&&"disabled"in n}var W=class extends y{constructor(e=null,t,i){super(Y(t),X(i,t)),this.defaultValue=null,this._onChange=[],this._pendingChange=!1,this._applyFormState(e),this._setUpdateStrategy(t),this._initObservables(),this.updateValueAndValidity({onlySelf:!0,emitEvent:!!this.asyncValidator}),G(t)&&(t.nonNullable||t.initialValueIsDefault)&&(Ae(e)?this.defaultValue=e.value:this.defaultValue=e)}setValue(e,t={}){this.value=this._pendingValue=e,this._onChange.length&&t.emitModelToViewChange!==!1&&this._onChange.forEach(i=>i(this.value,t.emitViewToModelChange!==!1)),this.updateValueAndValidity(t)}patchValue(e,t={}){this.setValue(e,t)}reset(e=this.defaultValue,t={}){this._applyFormState(e),this.markAsPristine(t),this.markAsUntouched(t),this.setValue(this.value,t),this._pendingChange=!1}_updateValue(){}_anyControls(e){return!1}_allControlsDisabled(){return this.disabled}registerOnChange(e){this._onChange.push(e)}_unregisterOnChange(e){be(this._onChange,e)}registerOnDisabledChange(e){this._onDisabledChange.push(e)}_unregisterOnDisabledChange(e){be(this._onDisabledChange,e)}_forEachChild(e){}_syncPendingControls(){return this.updateOn==="submit"&&(this._pendingDirty&&this.markAsDirty(),this._pendingTouched&&this.markAsTouched(),this._pendingChange)?(this.setValue(this._pendingValue,{onlySelf:!0,emitModelToViewChange:!1}),!0):!1}_applyFormState(e){Ae(e)?(this.value=this._pendingValue=e.value,e.disabled?this.disable({onlySelf:!0,emitEvent:!1}):this.enable({onlySelf:!0,emitEvent:!1})):this.value=this._pendingValue=e}};var Z=class extends y{constructor(e,t,i){super(Y(t),X(i,t)),this.controls=e,this._initObservables(),this._setUpdateStrategy(t),this._setUpControls(),this.updateValueAndValidity({onlySelf:!0,emitEvent:!!this.asyncValidator})}at(e){return this.controls[this._adjustIndex(e)]}push(e,t={}){this.controls.push(e),this._registerControl(e),this.updateValueAndValidity({emitEvent:t.emitEvent}),this._onCollectionChange()}insert(e,t,i={}){this.controls.splice(e,0,t),this._registerControl(t),this.updateValueAndValidity({emitEvent:i.emitEvent})}removeAt(e,t={}){let i=this._adjustIndex(e);i<0&&(i=0),this.controls[i]&&this.controls[i]._registerOnCollectionChange(()=>{}),this.controls.splice(i,1),this.updateValueAndValidity({emitEvent:t.emitEvent})}setControl(e,t,i={}){let r=this._adjustIndex(e);r<0&&(r=0),this.controls[r]&&this.controls[r]._registerOnCollectionChange(()=>{}),this.controls.splice(r,1),t&&(this.controls.splice(r,0,t),this._registerControl(t)),this.updateValueAndValidity({emitEvent:i.emitEvent}),this._onCollectionChange()}get length(){return this.controls.length}setValue(e,t={}){Re(this,!1,e),e.forEach((i,r)=>{ke(this,!1,r),this.at(r).setValue(i,{onlySelf:!0,emitEvent:t.emitEvent})}),this.updateValueAndValidity(t)}patchValue(e,t={}){e!=null&&(e.forEach((i,r)=>{this.at(r)&&this.at(r).patchValue(i,{onlySelf:!0,emitEvent:t.emitEvent})}),this.updateValueAndValidity(t))}reset(e=[],t={}){this._forEachChild((i,r)=>{i.reset(e[r],{onlySelf:!0,emitEvent:t.emitEvent})}),this._updatePristine(t,this),this._updateTouched(t,this),this.updateValueAndValidity(t)}getRawValue(){return this.controls.map(e=>e.getRawValue())}clear(e={}){this.controls.length<1||(this._forEachChild(t=>t._registerOnCollectionChange(()=>{})),this.controls.splice(0),this.updateValueAndValidity({emitEvent:e.emitEvent}))}_adjustIndex(e){return e<0?e+this.length:e}_syncPendingControls(){let e=this.controls.reduce((t,i)=>i._syncPendingControls()?!0:t,!1);return e&&this.updateValueAndValidity({onlySelf:!0}),e}_forEachChild(e){this.controls.forEach((t,i)=>{e(t,i)})}_updateValue(){this.value=this.controls.filter(e=>e.enabled||this.disabled).map(e=>e.value)}_anyControls(e){return this.controls.some(t=>t.enabled&&e(t))}_setUpControls(){this._forEachChild(e=>this._registerControl(e))}_allControlsDisabled(){for(let e of this.controls)if(e.enabled)return!1;return this.controls.length>0||this.disabled}_registerControl(e){e.setParent(this),e._registerOnCollectionChange(this._onCollectionChange)}_find(e){return this.at(e)??null}};function Me(n){return!!n&&(n.asyncValidators!==void 0||n.validators!==void 0||n.updateOn!==void 0)}var Te=(()=>{class n{constructor(){this.useNonNullable=!1}get nonNullable(){let t=new n;return t.useNonNullable=!0,t}group(t,i=null){let r=this._reduceControls(t),s={};return Me(i)?s=i:i!==null&&(s.validators=i.validator,s.asyncValidators=i.asyncValidator),new R(r,s)}record(t,i=null){let r=this._reduceControls(t);return new z(r,i)}control(t,i,r){let s={};return this.useNonNullable?(Me(i)?s=i:(s.validators=i,s.asyncValidators=r),new W(t,a(o({},s),{nonNullable:!0}))):new W(t,i,r)}array(t,i,r){let s=t.map(l=>this._createControl(l));return new Z(s,i,r)}_reduceControls(t){let i={};return Object.keys(t).forEach(r=>{i[r]=this._createControl(t[r])}),i}_createControl(t){if(t instanceof W)return t;if(t instanceof y)return t;if(Array.isArray(t)){let i=t[0],r=t.length>1?t[1]:null,s=t.length>2?t[2]:null;return this.control(i,r,s)}else return this.control(t)}static{this.\u0275fac=function(i){return new(i||n)}}static{this.\u0275prov=m({token:n,factory:n.\u0275fac,providedIn:"root"})}}return n})();var j=class n{constructor(e){this.http=e}apiUrl="http://localhost:16725";createSession(){return this.http.post(`${this.apiUrl}/session`,{})}static \u0275fac=function(t){return new(t||n)(ie(O))};static \u0275prov=m({token:n,factory:n.\u0275fac,providedIn:"root"})};var B=class n{constructor(e,t,i){this.fb=e;this.http=t;this.sessionService=i;this.sessionForm=this.fb.group({sessionToken:["",x.required]})}sessionForm;appName="DateDetective";ngOnInit(){}submitSessionToken(){this.sessionForm.valid&&console.log(this.sessionForm.value)}onCreateSession(){this.sessionService.createSession().subscribe(e=>{this.sessionForm.patchValue({sessionToken:e.SessionToken}),console.log("Session created:",e)})}onButtonWorks(){console.log("Button works.")}static \u0275fac=function(t){return new(t||n)(C(Te),C(O),C(j))};static \u0275cmp=F({type:n,selectors:[["app-session"]],standalone:!0,features:[S],decls:12,vars:0,consts:[[1,"session-container"],[1,"form-group"],["for","token"],["id","token","type","text","placeholder","Enter session token"],[1,"button-group"],[3,"click"]],template:function(t,i){t&1&&(d(0,"div",0)(1,"h2"),h(2,"Session Manager"),u(),d(3,"div",1)(4,"label",2),h(5,"Session Token"),u(),w(6,"input",3),u(),d(7,"div",4)(8,"button"),h(9,"Submit"),u(),d(10,"button",5),$("click",function(){return i.onButtonWorks()}),h(11,"Create New Session"),u()()())},styles:[".session-container[_ngcontent-%COMP%]{max-width:400px;margin:2rem auto;padding:1.5rem;background-color:#f9f9f9;border-radius:12px;box-shadow:0 4px 10px #0000001a}.session-container[_ngcontent-%COMP%]   h2[_ngcontent-%COMP%]{text-align:center;margin-bottom:1rem;color:#333}.session-container[_ngcontent-%COMP%]   .form-group[_ngcontent-%COMP%]{display:flex;flex-direction:column;margin-bottom:1rem}.session-container[_ngcontent-%COMP%]   .form-group[_ngcontent-%COMP%]   label[_ngcontent-%COMP%]{margin-bottom:.5rem;font-weight:600}.session-container[_ngcontent-%COMP%]   .form-group[_ngcontent-%COMP%]   input[_ngcontent-%COMP%]{padding:.5rem;border:1px solid #ccc;border-radius:8px;font-size:1rem}.session-container[_ngcontent-%COMP%]   .button-group[_ngcontent-%COMP%]{display:flex;justify-content:space-between}.session-container[_ngcontent-%COMP%]   .button-group[_ngcontent-%COMP%]   button[_ngcontent-%COMP%]{padding:.5rem 1rem;border:none;background-color:#1976d2;color:#fff;font-size:1rem;border-radius:8px;cursor:pointer;transition:background-color .2s ease-in-out}.session-container[_ngcontent-%COMP%]   .button-group[_ngcontent-%COMP%]   button[_ngcontent-%COMP%]:hover{background-color:#125ea2}"]})};var U=class n{static \u0275fac=function(t){return new(t||n)};static \u0275cmp=F({type:n,selectors:[["app-root"]],standalone:!0,features:[S],decls:3,vars:0,template:function(t,i){t&1&&(d(0,"h1"),h(1,"Date Detective"),u(),w(2,"app-session"))},dependencies:[pe,B],styles:["h1[_ngcontent-%COMP%]{text-align:center;margin-bottom:1.5rem;font-size:2rem;color:red}"]})};var Ge=[];var lt="@",ut=(()=>{class n{constructor(t,i,r,s,l){this.doc=t,this.delegate=i,this.zone=r,this.animationType=s,this.moduleImpl=l,this._rendererFactoryPromise=null,this.scheduler=M(ae,{optional:!0}),this.loadingSchedulerFn=M(ct,{optional:!0})}ngOnDestroy(){this._engine?.flush()}loadImpl(){let t=()=>this.moduleImpl??import("./chunk-DZCYC42J.mjs").then(r=>r),i;return this.loadingSchedulerFn?i=this.loadingSchedulerFn(t):i=t(),i.catch(r=>{throw new p(5300,!1)}).then(({\u0275createEngine:r,\u0275AnimationRendererFactory:s})=>{this._engine=r(this.animationType,this.doc);let l=new s(this.delegate,this._engine,this.zone);return this.delegate=l,l})}createRenderer(t,i){let r=this.delegate.createRenderer(t,i);if(r.\u0275type===0)return r;typeof r.throwOnSyntheticProps=="boolean"&&(r.throwOnSyntheticProps=!1);let s=new K(r);return i?.data?.animation&&!this._rendererFactoryPromise&&(this._rendererFactoryPromise=this.loadImpl()),this._rendererFactoryPromise?.then(l=>{let He=l.createRenderer(t,i);s.use(He),this.scheduler?.notify(10)}).catch(l=>{s.use(r)}),s}begin(){this.delegate.begin?.()}end(){this.delegate.end?.()}whenRenderingDone(){return this.delegate.whenRenderingDone?.()??Promise.resolve()}static{this.\u0275fac=function(i){oe()}}static{this.\u0275prov=m({token:n,factory:n.\u0275fac})}}return n})(),K=class{constructor(e){this.delegate=e,this.replay=[],this.\u0275type=1}use(e){if(this.delegate=e,this.replay!==null){for(let t of this.replay)t(e);this.replay=null}}get data(){return this.delegate.data}destroy(){this.replay=null,this.delegate.destroy()}createElement(e,t){return this.delegate.createElement(e,t)}createComment(e){return this.delegate.createComment(e)}createText(e){return this.delegate.createText(e)}get destroyNode(){return this.delegate.destroyNode}appendChild(e,t){this.delegate.appendChild(e,t)}insertBefore(e,t,i,r){this.delegate.insertBefore(e,t,i,r)}removeChild(e,t,i){this.delegate.removeChild(e,t,i)}selectRootElement(e,t){return this.delegate.selectRootElement(e,t)}parentNode(e){return this.delegate.parentNode(e)}nextSibling(e){return this.delegate.nextSibling(e)}setAttribute(e,t,i,r){this.delegate.setAttribute(e,t,i,r)}removeAttribute(e,t,i){this.delegate.removeAttribute(e,t,i)}addClass(e,t){this.delegate.addClass(e,t)}removeClass(e,t){this.delegate.removeClass(e,t)}setStyle(e,t,i,r){this.delegate.setStyle(e,t,i,r)}removeStyle(e,t,i){this.delegate.removeStyle(e,t,i)}setProperty(e,t,i){this.shouldReplay(t)&&this.replay.push(r=>r.setProperty(e,t,i)),this.delegate.setProperty(e,t,i)}setValue(e,t){this.delegate.setValue(e,t)}listen(e,t,i){return this.shouldReplay(t)&&this.replay.push(r=>r.listen(e,t,i)),this.delegate.listen(e,t,i)}shouldReplay(e){return this.replay!==null&&e.startsWith(lt)}},ct=new H("");function je(n="animations"){return ue("NgAsyncAnimations"),ne([{provide:le,useFactory:(e,t,i)=>new ut(e,t,i,n),deps:[fe,ge,re]},{provide:se,useValue:n==="noop"?"NoopAnimations":"BrowserAnimations"}])}var Be={providers:[de({eventCoalescing:!0}),Ce(Ge),ve(),je(),me()]};var dt={providers:[ye()]},Ue=he(Be,dt);var ht=()=>_e(U,Ue),Di=ht;export{Di as a};
