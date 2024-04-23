import { NgModule } from '@angular/core';
import { AdminSharedModule } from '@app/admin/shared/admin-shared.module';
import { AppSharedModule } from '@app/shared/app-shared.module';
import { ScheduleComponent } from './schedule.component';
import { ScheduleRoutingModule } from './schedule.routing.module';

@NgModule({
  declarations: [
    ScheduleComponent,
  ],
  imports: [AppSharedModule, AdminSharedModule, ScheduleRoutingModule],
})
export class ScheduleModule { }
