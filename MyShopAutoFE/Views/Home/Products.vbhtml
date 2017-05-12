﻿@Code
    ViewData("Title") = "Contact"
End Code


<div class="row">

    <div class="col-md-2">
        <h1>Multi-Level Accordion Menu</h1>
        <ul class="cd-accordion-menu animated">
            <li class="has-children">
                <input type="checkbox" name="group-1" id="group-1" checked>
                <label for="group-1">Group 1</label>
                <ul>
                    <li class="has-children">
                        <input type="checkbox" name="sub-group-1" id="sub-group-1">
                        <label for="sub-group-1">Sub Group 1</label>
                        <ul>
                            <li><a href="#0">Image</a></li>
                            <li><a href="#0">Image</a></li>
                            <li><a href="#0">Image</a></li>
                        </ul>
                    </li>
                    <li class="has-children">
                        <input type="checkbox" name="sub-group-2" id="sub-group-2">
                        <label for="sub-group-2">Sub Group 2</label>
                        <ul>
                            <li class="has-children">
                                <input type="checkbox" name="sub-group-level-3" id="sub-group-level-3">
                                <label for="sub-group-level-3">Sub Group Level 3</label>
                                <ul>
                                    <li><a href="#0">Image</a></li>
                                    <li><a href="#0">Image</a></li>
                                </ul>
                            </li>
                            <li><a href="#0">Image</a></li>
                        </ul>
                    </li>
                    <li><a href="#0">Image</a></li>
                    <li><a href="#0">Image</a></li>
                </ul>
            </li>
            <li class="has-children">
                <input type="checkbox" name="group-2" id="group-2">
                <label for="group-2">Group 2</label>
                <ul>
                    <li><a href="#0">Image</a></li>
                    <li><a href="#0">Image</a></li>
                </ul>
            </li>
            <li class="has-children">
                <input type="checkbox" name="group-3" id="group-3">
                <label for="group-3">Group 3</label>
                <ul>
                    <li><a href="#0">Image</a></li>
                    <li><a href="#0">Image</a></li>
                </ul>
            </li>
            <li class="has-children">
                <input type="checkbox" name="group-4" id="group-4">
                <label for="group-4">Group 4</label>
                <ul>
                    <li class="has-children">
                        <input type="checkbox" name="sub-group-3" id="sub-group-3">
                        <label for="sub-group-3">Sub Group 3</label>
                        <ul>
                            <li><a href="#0">Image</a></li>
                            <li><a href="#0">Image</a></li>
                        </ul>
                    </li>
                    <li><a href="#0">Image</a></li>
                    <li><a href="#0">Image</a></li>
                </ul>
            </li>
        </ul> <!-- cd-accordion-menu -->

    </div>
</div>