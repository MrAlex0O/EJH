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

const appRoutes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'about', component: AboutComponent },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'profile', component: ProfileComponent },
  { path: 'groupManager', component: GroupManagerComponent },
  { path: 'teacherManager', component: TeacherManagerComponent },
  { path: 'disciplineManager', component: DisciplineManagerComponent },
  { path: '**', component: NotFoundComponent },
]


@NgModule({
  declarations: [
    AppComponent,
    DisciplineComboBoxComponent,
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
    DisciplineManagerComponent

  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    FormsModule, ReactiveFormsModule,
    MaterialAppModule,
    RouterModule.forRoot(appRoutes),
    HttpClientModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: HttpRequestInterceptor, multi: true },

    DisciplineService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
