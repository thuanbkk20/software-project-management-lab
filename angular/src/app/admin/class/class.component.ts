import { Component, OnInit, Injector } from '@angular/core';
import { ActivatedRoute } from '@angular/router'; // Import ActivatedRoute
import { AppComponentBase } from '@shared/common/app-component-base';
import {
    ClassListDto,
    ClassServiceProxy,
    ClassStudentDto,
    ListResultDtoOfClassStudentDto,
} from '@shared/service-proxies/service-proxies';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Component({
    selector: 'class',
    templateUrl: './class.component.html',
})
export class ClassComponent extends AppComponentBase implements OnInit {
    students: ClassStudentDto[] = [];
    class: ClassListDto;
    classId: number;

    constructor(
        injector: Injector,
        private _classService: ClassServiceProxy,
        private route: ActivatedRoute // Inject ActivatedRoute
    ) {
        super(injector);
    }

    ngOnInit(): void {
        this.getClassId().subscribe((classId) => {
            this.classId = parseInt(classId);
            this.getStudents();
            this.getClass();
        });
    }

    getClassId(): Observable<string> {
        return this.route.paramMap.pipe(map((params) => params.get('classId')));
    }

    getStudents(): void {
        this.primengTableHelper.showLoadingIndicator();
        this._classService.getClassStudent(this.classId).subscribe((result: ListResultDtoOfClassStudentDto) => {
            this.students = result.items;
            this.primengTableHelper.totalRecordsCount = result.items.length;
            this.primengTableHelper.records = result.items;
        });
        this.primengTableHelper.hideLoadingIndicator();
    }

    getClass(): void {
        this._classService.getClassDetail(this.classId).subscribe((result) => {
            this.class = result;
        });
    }
}
