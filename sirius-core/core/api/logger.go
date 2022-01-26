package api

import (
	"fmt"
	"path/filepath"
	"runtime"
	"sirius-core/core/native"
	"strings"
)

var (
	apiLogger         = logger{}
	outputFuncAddress uintptr
)

type logger struct {
}

func SetOpenApiLogOutputFunc(funcAddress uintptr) {
	outputFuncAddress = funcAddress
}

func (logger) Success(content string) {
	output("Success", content, nil)
}

func (logger) Error(content string, err error) {
	output("Error", content, err)
}

func (logger) Successf(format string, v ...interface{}) {
	output("Success", fmt.Sprintf(format, v...), nil)
}

func (logger) Errorf(err error, format string, v ...interface{}) {
	output("Error", fmt.Sprintf(format, v...), err)
}

func output(label string, content string, err error) {
	pc, file, line, _ := runtime.Caller(3)
	file = filepath.Base(file)
	funcFullName := runtime.FuncForPC(pc).Name()
	funcName := strings.TrimPrefix(filepath.Ext(funcFullName), ".")

	if err != nil {
		_, _, _ = native.Call(
			outputFuncAddress,
			native.StringPtr(label),
			native.StringPtr(content),
			native.StringPtr(file),
			native.IntPtr(line),
			native.StringPtr(funcName),
			native.StringPtr(err.Error()),
		)
	} else {
		_, _, _ = native.Call(
			outputFuncAddress,
			native.StringPtr(label),
			native.StringPtr(content),
			native.StringPtr(file),
			native.IntPtr(line),
			native.StringPtr(funcName),
			native.IntPtr(0),
		)
	}

}
