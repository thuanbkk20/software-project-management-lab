import { Component, Injector} from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ClassListDto, ClassServiceProxy, CreateScheduleInput, ScheduleServiceProxy, TeacherDto, TeacherServiceProxy } from '@shared/service-proxies/service-proxies';

@Component({
    selector: 'AddSchedule',
    templateUrl: './add-schedule.component.html',
})
export class AddScheduleComponent extends AppComponentBase {

    schedule: CreateScheduleInput = new CreateScheduleInput();
    classes: ClassListDto[] = [];
    teachers: TeacherDto[] = [];

    constructor(injector: Injector, 
        private _scheduleService: ScheduleServiceProxy,
        private _classService: ClassServiceProxy,
        private _teacherService: TeacherServiceProxy) {
        super(injector);
    }

    ngOnInit(): void {
        this.getTeachers();
        this.getClasses();
    }

    getTeachers(): void {
        this._teacherService.getTeacher(undefined).subscribe((result)=>{
            this.teachers = result.items;
            console.log(this.teachers);
        })
    }

    getClasses(): void {
        this._classService.getClass(undefined).subscribe((result)=>{
            this.classes = result.items;
            console.log(this.classes);
        })
    }

    addSchedule(): void {
        console.log(this.schedule);
        this._scheduleService.createSchedule(this.schedule).subscribe((result) => {
            // Handle success, maybe show a success message or redirect
            window.alert('Schedule added successfully');
            // Clear the form after adding the schedule
            this.schedule = new CreateScheduleInput();
        }, (error) => {
            // Handle error
            console.error('Error adding schedule:', error);
        });
    }
}
