import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { Routes, RouterModule } from '@angular/router'
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http'
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialAppModule } from './ngmaterial.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { AboutComponent } from './about/about.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { HttpRequestInterceptor } from './_helpers/http.interceptor';
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';
import { ProfileComponent } from './profile/profile.component';
import { GroupManagerComponent } from './group-manager/group-manager.component';
import { TeacherManagerComponent } from './teacher-manager/teacher-manager.component';
import { DisciplineManagerComponent } from './discipline-manager/discipline-manager.component';
import { StudentManagerComponent } from './student-manager/student-manager.component';
import { LessonManagerComponent } from './lesson-manager/lesson-manager.component';
import { VisitorManagerComponent } from './visitor-manager/visitor-manager.component';
import { GenericTableComponent } from './generic-table/generic-table.component';
import { ReportManagerComponent } from './report-manager/report-manager.component';
import { GenericComboBoxComponent } from './generic-combo-box/generic-combo-box.component';
import { AuthGuard } from './_helpers/auth.guard';
import { Role } from './_models/roleModel';
const appRoutes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'about', component: AboutComponent },
  { path: 'login', component: LoginComponent },
  {
    path: 'register', component: RegisterComponent,
    canActivate: [AuthGuard], data: { roles: [Role.Admin] }
  },
  {
    path: 'profile', component: ProfileComponent,
    canActivate: [AuthGuard], data: { roles: [Role.Admin, Role.Headman, Role.Teacher] }
  },
  {
    path: 'groupManager', component: GroupManagerComponent,
    canActivate: [AuthGuard], data: { roles: [Role.Admin, Role.Headman] }
  },
  {
    path: 'teacherManager', component: TeacherManagerComponent,
    canActivate: [AuthGuard], data: { roles: [Role.Admin, Role.Teacher] }
  },
  {
    path: 'disciplineManager', component: DisciplineManagerComponent,
    canActivate: [AuthGuard], data: { roles: [Role.Admin, Role.Headman] }
  },
  {
    path: 'studentManager', component: StudentManagerComponent,
    canActivate: [AuthGuard], data: { roles: [Role.Admin, Role.Headman] }
  },
  {
    path: 'lessonManager', component: LessonManagerComponent,
    canActivate: [AuthGuard], data: { roles: [Role.Admin, Role.Headman, Role.Teacher] }
  },
  {
    path: 'visitorManager', component: VisitorManagerComponent,
    canActivate: [AuthGuard], data: { roles: [Role.Admin, Role.Headman, Role.Teacher] }
  },
  {
    path: 'reportManager', component: ReportManagerComponent,
    canActivate: [AuthGuard], data: { roles: [Role.Admin, Role.Teacher] }
  },
  { path: '**', component: NotFoundComponent },
]

@NgModule({
  declarations: [
    AppComponent,
    GenericComboBoxComponent,
    DisciplineManagerComponent,
    HomeComponent,
    AboutComponent,
    NotFoundComponent,
    RegisterComponent,
    LoginComponent,
    ProfileComponent,
    GroupManagerComponent,
    TeacherManagerComponent,
    StudentManagerComponent,
    LessonManagerComponent,
    VisitorManagerComponent,
    GenericTableComponent,
    ReportManagerComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    FormsModule, ReactiveFormsModule,
    RouterModule.forRoot(appRoutes), HttpClientModule,
    MaterialAppModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: HttpRequestInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
