/**
 * Render Rows to Default Listing Table
 * @param {object} data
 * @return string
 */
export const generateBody = data => {
    let rows = "";

    for (const row of data)
        rows += generateRow(row)

    return rows;
}

/**
 * Render cells of row
 * @param {object} row
 * @return string
 */
const generateRow = row => {
    let cells = "";

    for (const cell of Object.values(row))
        cells += `<td>${cell}</td>`;

    return `<tr>${cells}<td class="p-1 align-middle text-right">
        ${getHTMLBtnEdit(row.id)} ${getHTMLBtnDelete(row.id)}</td></tr>`;
}

const getHTMLBtnEdit = id => {
    return `<button onclick="location.href='/Courses/Update/${id}'"
            class="btn btn-outline-primary p-1 px-2 mr-0">
            <i class="far fa-edit m-0"></i>
        </button>`;
}

const getHTMLBtnDelete = id => {
    return `<button data-toggle="modal" data-target="#myModal"
            class="btn btn-outline-danger p-1 px-2" data-id="${id}">
            <i class="feather icon-trash-2 m-0"></i>
        </button>`;
}

/**
 * Render Rows to Default Listing Table Activities
 * @param {data} data
 */
export const generateActivities = data => {
    let rows = "";

    for (const row of data)
        rows += generateRowActivities(row)

    return rows;
}

function generateRowActivities(row) {
    return `<tr><td><img class="rounded-circle" style="width:40px;" src="/theme/assets/images/user/${row.img}.jpg"></td>
            <td>
                <h6 class="mb-1">${row.name}</h6>
                <p class="m-0">${row.description}</p>
            </td>
            <td>
                <h6 class="text-muted"><i class="fas fa-circle text-c-${row.status == "active" ? "green" : "red"} f-10 m-r-15"></i>${row.date}</h6>
            </td>
        </tr>`;
}