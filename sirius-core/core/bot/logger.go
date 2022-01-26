package bot

import (
	"fmt"
	"github.com/tencent-connect/botgo"
	"github.com/tencent-connect/botgo/log"
	"path/filepath"
	"runtime"
	"sirius-core/core/native"
	"strings"
)

var customLogger log.Logger = logger{}

var outputFuncAddress uintptr

type logger struct {
}

func SetGoLogOutputFunc(funcAddress uintptr) {
	outputFuncAddress = funcAddress
	botgo.SetLogger(customLogger)
}

// Debug 日志
func (logger) Debug(v ...interface{}) {
	output("Debug", fmt.Sprint(v...))
}

// Info 日志
func (logger) Info(v ...interface{}) {
	output("Info", fmt.Sprint(v...))
}

// Warn 日志
func (logger) Warn(v ...interface{}) {
	output("Warn", fmt.Sprint(v...))
}

// Error
func (logger) Error(v ...interface{}) {
	output("Error", fmt.Sprint(v...))
}


// Debugf Debug Format 日志
func (logger) Debugf(format string, v ...interface{}) {
	output("Debug", fmt.Sprintf(format, v...))
}

// Infof Info Format 日志
func (logger) Infof(format string, v ...interface{}) {
	output("Info", fmt.Sprintf(format, v...))
}

// Warnf Warning Format 日志
func (logger) Warnf(format string, v ...interface{}) {
	output("Warn", fmt.Sprintf(format, v...))
}

// Errorf Error Format 日志
func (logger) Errorf(format string, v ...interface{}) {
	output("Error", fmt.Sprintf(format, v...))
}

func (logger) Sync() error {
	return nil
}

func output(level string, content string) {
	pc, file, line, _ := runtime.Caller(3)
	file = filepath.Base(file)
	funcName := strings.TrimPrefix(filepath.Ext(runtime.FuncForPC(pc).Name()), ".")

	_, _, _ = native.Call(
		outputFuncAddress,
		native.StringPtr(level),
		native.StringPtr(content),
		native.StringPtr(file),
		native.IntPtr(line),
		native.StringPtr(funcName),
	)

}
