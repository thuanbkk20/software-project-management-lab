import { Component, Injector, OnInit, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import {
    ListResultDtoOfScheduleDto,
    ScheduleDto,
    ScheduleServiceProxy,
} from '@shared/service-proxies/service-proxies';
import { forEach as _forEach } from 'lodash-es';

@Component({
    templateUrl: './schedule.component.html',
    animations: [appModuleAnimation()],
})
export class ScheduleComponent extends AppComponentBase implements OnInit {
    schedules: ScheduleDto[] = [];

    constructor(injector: Injector, private _scheduleService: ScheduleServiceProxy){
        super(injector);
    }

    ngOnInit(): void {
        this.getTeacherSchedule();
    }

    getTeacherSchedule(): void {
        this.renderTeacherSchedule(true, undefined, undefined);
    }

    renderTeacherSchedule(getByCurrentUser: boolean, classId: number | undefined, teacherId: number | undefined): void {
        this.primengTableHelper.showLoadingIndicator();
        this._scheduleService.getSchedule(getByCurrentUser, classId, teacherId)
            .subscribe((result: ListResultDtoOfScheduleDto) => {
                this.schedules = result.items;
                this.primengTableHelper.totalRecordsCount = result.items.length;
                this.primengTableHelper.records = result.items;
            });
        this.primengTableHelper.hideLoadingIndicator();
    }
}
