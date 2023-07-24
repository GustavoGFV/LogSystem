import { LogDto } from "../../interface/log-dto";
import { Component, OnInit } from "@angular/core";
import { FormGroup, FormControl, FormBuilder } from "@angular/forms";
import { SearchForm } from "../../class/search-form";
import { ApiService } from "src/app/core/api/api.service";
import { Observable, catchError, throwError } from "rxjs";
import { HttpErrorResponse } from "@angular/common/http";

@Component({
  selector: "app-main",
  template: `
    <section class="section is-mobile">
      <div class="container is-mobile">
        <h1 class="title">Pesquisar Log</h1>
        <div class="box is-mobile">
          <form class="form" [formGroup]="searchForm" (ngSubmit)="onSubmit()">
            <div class="field">
              <label class="label">Id:</label>
              <div class="control">
                <input class="input" type="number" formControlName="id" />
              </div>
            </div>
            <div class="field">
              <label class="label">Código de Erro:</label>
              <div class="control">
                <input class="input" type="number" formControlName="code" />
              </div>
            </div>
            <div class="field">
              <h1 class="subtitle">Périodo do Erro:</h1>
              <label class="label">Data Inicial:</label>
              <div class="control">
                <input
                  class="input"
                  type="datetime-local"
                  formControlName="initialDate"
                />
              </div>
            </div>
            <div class="field">
              <label class="label">Data Final:</label>
              <div class="control">
                <input
                  class="input"
                  type="datetime-local"
                  formControlName="finalDate"
                />
              </div>
            </div>
            <div class="field">
              <div class="control">
                <button
                  class="button is-primary"
                  type="submit"
                  [disabled]="!searchForm.valid"
                >
                  Enviar
                </button>
              </div>
            </div>
          </form>
        </div>
      </div>
      <hr />
      <div class="container is-mobile">
        <table class="table is-mobile is-striped is-fullwidth">
          <thead>
            <tr>
              <th>Id</th>
              <th>Projeto</th>
              <th>Código</th>
              <th>Mensagem</th>
              <th>Data</th>
              <th>StackTrace</th>
            </tr>
          </thead>
          <tbody *ngFor="let log; in: logs">
            <tr>
              <td>{{ log.id }}</td>
              <td>{{ log.project }}</td>
              <td>{{ log.code }}</td>
              <td>{{ log.message }}</td>
              <td>{{ log.stackTrace }}</td>
              <td>{{ log.date }}</td>
            </tr>
          </tbody>
          <tfoot>
            <tr>
              <th></th>
              <th></th>
              <th></th>
              <th></th>
              <th></th>
              <th></th>
            </tr>
          </tfoot>
        </table>
      </div>
    </section>
  `,
  styles: [],
})
export class MainComponent implements OnInit {
  searchForm: any;
  logs: Array<LogDto>[] = [];

  constructor(private formBuilder: FormBuilder, private api: ApiService) {}

  ngOnInit() {
    this.createForm(new SearchForm());

    this.api.getAll().subscribe((data) => {
      this.logs.push(data);
    });
  }

  createForm(search: SearchForm) {
    this.searchForm = new FormGroup({
      id: new FormControl(search.id),
      code: new FormControl(search.code),
      initialDate: new FormControl(search.initialDate),
      finalDate: new FormControl(search.finalDate),
    });
  }

  onSubmit() {
    if (
      this.searchForm.value.initialDate != null &&
      this.searchForm.value.finalDate == null
    ) {
      this.searchForm.value.finalDate = this.searchForm.value.initialDate;
    } else if (
      this.searchForm.value.initialDate == null &&
      this.searchForm.value.finalDate != null
    ) {
      this.searchForm.value.initialDate = this.searchForm.value.finalDate;
    }

    if (this.searchForm.value.id != null) {
      this.api.getId(this.searchForm.value.id).subscribe((data) => {
        this.logs.push(data);
      });
    } else if (
      this.searchForm.value.code != null &&
      this.searchForm.value.initialDate != null
    ) {
      this.api.getCodeDate(
        this.searchForm.value.initialDate,
        this.searchForm.value.finalDate,
        this.searchForm.value.code
      );
    } else if (this.searchForm.value.code != null) {
      this.api.getCode(this.searchForm.value.code).subscribe((data) => {
        this.logs.push(data);
      });
    } else if (this.searchForm.value.initialDate != null) {
      this.api
        .getDate(
          this.searchForm.value.initialDate,
          this.searchForm.value.finalDate
        )
        .subscribe((data) => {
          this.logs.push(data);
        });
    }
  }
}
