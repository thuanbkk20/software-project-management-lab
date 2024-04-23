import { NgModule } from '@angular/core';
import { AdminSharedModule } from '@app/admin/shared/admin-shared.module';
import { AppSharedModule } from '@app/shared/app-shared.module';

import { AddScheduleComponent} from './add-schedule.component';
import { AddScheduleRoutingModule } from './add-schedule.routing';

@NgModule({
  declarations: [
    AddScheduleComponent,
  ],
  imports: [AppSharedModule, AdminSharedModule, AddScheduleRoutingModule],
})
export class AddScheduleModule { }
