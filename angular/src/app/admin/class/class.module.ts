import { NgModule } from '@angular/core';
import { AdminSharedModule } from '@app/admin/shared/admin-shared.module';
import { AppSharedModule } from '@app/shared/app-shared.module';

import { ClassComponent } from './class.component';
import { ClassRoutingComponent } from './class.routing';

@NgModule({
    declarations: [ClassComponent],
    imports: [AppSharedModule, AdminSharedModule, ClassRoutingComponent],
})
export class ClassModule {}
