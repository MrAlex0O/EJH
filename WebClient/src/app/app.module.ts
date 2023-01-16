import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { Routes, RouterModule } from '@angular/router'
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http'


import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialAppModule } from './ngmaterial.module';
import { AppComponent } from './app.component';
import { DisciplineComboBoxComponent } from './discipline-combo-box/discipline-combo-box.component';
import { HomeComponent } from './home/home.component';
import { AboutComponent } from './about/about.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { DisciplineService } from './_services/discipline.service';
import { HttpRequestInterceptor } from './_helpers/http.inceptor';
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';
import { ProfileComponent } from './profile/profile.component';
import { GroupComboBoxComponent } from './group-combo-box/group-combo-box.component';
import { GroupManagerComponent } from './group-manager/group-manager.component';
import { TeacherComboBoxComponent } from './teacher-combo-box/teacher-combo-box.component';
import { TeacherManagerComponent } from './teacher-manager/teacher-manager.component';
import { DisciplineManagerComponent } from './discipline-manager/discipline-manager.component';
import { StudentComboBoxComponent } from './student-combo-box/student-combo-box.component';
import { StudentManagerComponent } from './student-manager/student-manager.component';
import { LessonTypeComboBoxComponent } from './lesson-type-combo-box/lesson-type-combo-box.component';
import { LessonManagerComponent } from './lesson-manager/lesson-manager.component';
import { LessonComboBoxComponent } from './lesson-combo-box/lesson-combo-box.component';
import { MatNativeDateModule } from '@angular/material/core';
import { MatDatepickerModule, } from '@angular/material/datepicker';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatTableModule } from '@angular/material/table';
import { MatSidenavModule } from '@angular/material/sidenav'
import { MatListModule } from '@angular/material/list'
import { VisitorManagerComponent } from './visitor-manager/visitor-manager.component';
import { StudentVisitComponent } from './student-visit/student-visit.component';
const appRoutes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'about', component: AboutComponent },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'profile', component: ProfileComponent },
  { path: 'groupManager', component: GroupManagerComponent },
  { path: 'teacherManager', component: TeacherManagerComponent },
  { path: 'disciplineManager', component: DisciplineManagerComponent },
  { path: 'studentManager', component: StudentManagerComponent },
  { path: 'lessonManager', component: LessonManagerComponent },
  { path: 'visitorManager', component: VisitorManagerComponent },
  { path: '**', component: NotFoundComponent },
]


@NgModule({
  declarations: [
    AppComponent,
    DisciplineComboBoxComponent,
    DisciplineManagerComponent,
    HomeComponent,
    AboutComponent,
    NotFoundComponent,
    RegisterComponent,
    LoginComponent,
    ProfileComponent,
    GroupComboBoxComponent,
    GroupManagerComponent,
    TeacherComboBoxComponent,
    TeacherManagerComponent,
    StudentComboBoxComponent,
    StudentManagerComponent,
    LessonTypeComboBoxComponent,
    LessonManagerComponent,
    LessonComboBoxComponent,
    VisitorManagerComponent,
    StudentVisitComponent

  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    FormsModule, ReactiveFormsModule,
    RouterModule.forRoot(appRoutes),HttpClientModule, 
    MaterialAppModule, MatFormFieldModule, MatInputModule,
    MatDatepickerModule, MatNativeDateModule, MatTableModule,
    MatListModule,

    MatSidenavModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: HttpRequestInterceptor, multi: true },

    DisciplineService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
