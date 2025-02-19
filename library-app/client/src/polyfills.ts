/***************************************************************************************************
 * Load `$localize` - used if i18n tags appear in Angular templates.
 */
import '@angular/localize/init';

/***************************************************************************************************
 * BROWSER POLYFILLS
 */

/** IE9, IE10 and IE11 requires all of the following polyfills. **/
// import 'core-js/es6/symbol';
// import 'core-js/es6/object';
// import 'core-js/es6/function';
// import 'core-js/es6/parse-int';
// import 'core-js/es6/parse-float';
// import 'core-js/es6/number';
// import 'core-js/es6/math';
// import 'core-js/es6/string';
// import 'core-js/es6/date';
// import 'core-js/es6/array';
// import 'core-js/es6/regexp';
// import 'core-js/es6/map';
// import 'core-js/es6/set';

/** Evergreen browsers require these. **/
import 'core-js/es/reflect';

/** ALL Firefox browsers require the following to support `@angular/animation`. **/
import 'web-animations-js';

/***************************************************************************************************
 * Zone JS is required by Angular itself.
 */
import 'zone.js';  // Included with Angular CLI.

/***************************************************************************************************
 * APPLICATION IMPORTS
 */