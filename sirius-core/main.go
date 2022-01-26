package main

import (
	"fmt"
	"path/filepath"
	"runtime"
	"strings"
)

func main() {

	pc, _, _, ok := runtime.Caller(1)
	if ok {
		name := runtime.FuncForPC(pc).Name()
		fmt.Println(strings.TrimPrefix(filepath.Ext(name),"."))
	}
}
