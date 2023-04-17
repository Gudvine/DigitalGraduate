import React from "react";
import {Route, Routes} from "react-router";

import {Account} from "./pages/Account";
import {AboutPregraguateActivites} from "./pages/AboutPregraduateActivities";
import {EnrollmentAndGraduation} from "./pages/EnrollmentAndGraduation";
import {ScientificAdviser} from "./pages/ScientificAdviser";
import {EntranceTestResults} from "./pages/EntranceTestResults";
import {Layout} from "./components/Layout";
import {Certification} from "./pages/Certification";
import {ScientificPublications} from "./pages/ScientificPublications";
import {ScientificConferences} from "./pages/ScientificConferences";
import {ScientificCompetitions} from "./pages/ScientificCompetitions";
import {Patents} from "./pages/Patents";
import {CertificateOfStateProgramRegistration} from "./pages/CertificateOfStateProgramRegistration";
import {TuitionPayment} from "./pages/TuitionPayment";
import {GrantsParticipation} from "./pages/GrantsParticipation";
import {RegistrationFormPage} from "./pages/RegistrationFormPage";

function App() {
  return (
      <div>
          <Routes>
              <Route path={"/"} element={<Layout />}>
                  <Route index element={<Account />} />
                  <Route path={"registration"} element={<RegistrationFormPage />} />
                  <Route path={"aboutpregraguateactivites"} element={<AboutPregraguateActivites />} />
                  <Route path={"enrollmentandgraduation"} element={<EnrollmentAndGraduation />} />
                  <Route path={"scientificadviser"} element={<ScientificAdviser />} />
                  <Route path={"entrancetestresults"} element={<EntranceTestResults />} />
                  <Route path={"сertification"} element={<Certification />} />
                  <Route path={"scientificpublications"} element={<ScientificPublications />} />
                  <Route path={"scientificconferences"} element={<ScientificConferences />} />
                  <Route path={"scientificcompetitions"} element={<ScientificCompetitions />} />
                  <Route path={"patents"} element={<Patents />} />
                  <Route path={"certificateofstateprogramregistration"} element={<CertificateOfStateProgramRegistration />} />
                  <Route path={"tuitionpayment"} element={<TuitionPayment />} />
                  <Route path={"grantsparticipation"} element={<GrantsParticipation />} />
              </Route>
          </Routes>
      </div>
  );
}

export default App;
