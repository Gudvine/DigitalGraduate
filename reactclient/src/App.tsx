import React from "react";
import {Route, Routes} from "react-router";

import {Account} from "./pages/Account";
import {AboutPregraguateActivites} from "./pages/AboutPregraduateActivities";
import {EnrollmentAndGraduation} from "./pages/EnrollmentAndGraduation";
import {ScientificAdviser} from "./pages/ScientificAdviser";
import {EntranceTestResults} from "./pages/EntranceTestResults";
import {Layout} from "./components/Layout";

function App() {
  return (
      <div>
          <Routes>
              <Route path={"/"} element={<Layout />}>
                  <Route index element={<Account />} />
                  {/*<Route path={"register"} element={<RegistrationFormPage />} />*/}
                  <Route path={"aboutpregraguateactivites"} element={<AboutPregraguateActivites />} />
                  <Route path={"enrollmentandgraduation"} element={<EnrollmentAndGraduation />} />
                  <Route path={"scientificadviser"} element={<ScientificAdviser />} />
                  <Route path={"entrancetestresults"} element={<EntranceTestResults />} />
              </Route>
          </Routes>
      </div>
  );
}

export default App;
